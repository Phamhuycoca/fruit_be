using AutoMapper;
using onion_architecture.Application.Dto;
using onion_architecture.Application.Dto.Category;
using onion_architecture.Application.Dto.Fruit;
using onion_architecture.Application.Helper;
using onion_architecture.Application.IService;
using onion_architecture.Application.Wrappers.Concrete;
using onion_architecture.Domain.Entity;
using onion_architecture.Domain.Repositories;
using onion_architecture.Infrastructure.Exceptions;
using onion_architecture.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion_architecture.Application.Service
{
    public class PaymentsService : IPaymentsService
    {
        private readonly IMapper _mapper;
        private List<PaymentsItem> _items;
        private readonly IFruitRepository _fruitRepository;
        public PaymentsService(IMapper mapper, List<PaymentsItem> items,IFruitRepository fruitRepository)
        {
            _mapper = mapper;
            _items = items;
            _fruitRepository = fruitRepository;
        }
        public PagedDataResponse<PaymentsItem> Items(CommonListQuery commonList)
        {
            var query = _items.ToList();
            var fruits=_fruitRepository.GetAll();
            var querys = from qr in query
                         join fruit in fruits on qr.FruitId equals fruit.FruitId
                         select new PaymentsItem
                         { 
                             FruitId = qr.FruitId,
                             CartId = qr.CartId,
                             FruitPrice = qr.FruitPrice,
                             Quantity = qr.Quantity,
                             StoreId = qr.StoreId,
                             UserId=qr.UserId,
                             Payment_Price = qr.Payment_Price,
                             FruitImg=fruit.FruitImg,
                             FruitName=fruit.FruitName,
                         };
            var paginatedResult = PaginatedList<PaymentsItem>.ToPageList(querys.ToList(), commonList.page, commonList.limit);
            return new PagedDataResponse<PaymentsItem>(paginatedResult, 200, querys.Count());
        }

        public DataResponse<PaymentsItem> Payments(PaymentsItem dto)
        {
            var check = _items.Where(x => x.CartId == dto.CartId).SingleOrDefault();
            if (check == null)
            {
                dto.FruitPrice = _mapper.Map<FruitQuery>(_fruitRepository.GetAll().Where(x=>x.FruitId==dto.FruitId).SingleOrDefault()).FruitPrice;
                dto.Payment_Price = long.Parse(dto.FruitPrice) * dto.Quantity;
                _items.Add(dto);
                return new DataResponse<PaymentsItem>(dto, 200, "Thêm mới thành công");
            }
            throw new ApiException(400, "Thêm mới không thành công");
        }

        public DataResponse<PaymentsItem> Remove(long id)
        {
            var pay = _items.Where(x => x.CartId == id).SingleOrDefault();
            var item = _items.Remove(pay);
            if (item == null)
            {
                throw new ApiException(404, "Không tìm thấy thông tin");
            }
            return new DataResponse<PaymentsItem>(pay, 200, "Thành công");
        }

    }
}
