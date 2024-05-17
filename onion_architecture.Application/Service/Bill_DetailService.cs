using AutoMapper;
using onion_architecture.Application.Dto.Bill_Detail;
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
    public class Bill_DetailService : IBill_DetailService
    {
        private readonly IMapper _mapper;
        private readonly IBill_DetailRepository _bill_DetailRepository;
        private readonly IFruitRepository _fruitRepository;
        public Bill_DetailService(IMapper mapper, IBill_DetailRepository bill_DetailRepository,IFruitRepository fruitRepository)
        {
            _mapper = mapper;
            _bill_DetailRepository = bill_DetailRepository;
            _fruitRepository = fruitRepository;
        }

        public DataResponse<Bill_DetailQuery> Create(Bill_DetailDto dto)
        {
            var newData = _bill_DetailRepository.Create(_mapper.Map<Bill_Detail>(dto));
            if (newData != null)
            {
                return new DataResponse<Bill_DetailQuery>(_mapper.Map<Bill_DetailQuery>(newData), 200, "Thêm mới thành công");
            }
            throw new ApiException(400, "Thêm mới không thành công");
        }

        public DataResponse<Bill_DetailQuery> Delete(long id)
        {
            var data = _bill_DetailRepository.Delete(id);
            if (data != null)
            {
                return new DataResponse<Bill_DetailQuery>(_mapper.Map<Bill_DetailQuery>(data), 200, "Xóa thông tin thành công");
            }
            throw new ApiException(400, "Xóa không thành công");
        }

        public DataResponse<Bill_DetailQuery> GetById(long id)
        {
            var item = _bill_DetailRepository.GetById(id);
            if (item == null)
            {
                throw new ApiException(404, "Không tìm thấy thông tin");
            }
            return new DataResponse<Bill_DetailQuery>(_mapper.Map<Bill_DetailQuery>(item), 200, "Thành công");
        }

        public PagedDataResponse<Bill_DetailQuery> Items(CommonListQuery commonList)
        {
            var query = _mapper.Map<List<Bill_DetailQuery>>(_bill_DetailRepository.GetAll());
           
            var paginatedResult = PaginatedList<Bill_DetailQuery>.ToPageList(query, commonList.page, commonList.limit);
            return new PagedDataResponse<Bill_DetailQuery>(paginatedResult, 200, query.Count());
        }

        public List<Bill_Detail_Fruit> ItemsById(long id)
        {
            var bills = _mapper.Map<List<Bill_DetailQuery>>(_bill_DetailRepository.GetAll().Where(x=>x.BillId==id));
            var fruits = _mapper.Map<List<FruitQuery>>(_fruitRepository.GetAll());
            var query = from bill in bills
                        join fruit in fruits on bill.FruitId equals fruit.FruitId
                        select new Bill_Detail_Fruit
                        {
                            BillId= bill.BillId,
                            Bill_Detail_Id= bill.FruitId,
                            FruitId=bill.FruitId,
                            FruitImg=fruit.FruitImg,
                            FruitName=fruit.FruitName,
                            Quantity= bill.Quantity
                        };

            return query.ToList();
        }

        public DataResponse<Bill_DetailQuery> Update(Bill_DetailDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
