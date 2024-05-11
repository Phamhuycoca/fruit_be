using AutoMapper;
using onion_architecture.Application.Dto.Cart;
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
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;
        private readonly IFruitRepository _fruitRepository;
        public CartService(ICartRepository cartRepository, IMapper mapper, IFruitRepository fruitRepository)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
            _fruitRepository = fruitRepository;
        }
        public DataResponse<CartQuery> Create(CartDto dto)
        {
            var newData = _cartRepository.Create(_mapper.Map<Cart>(dto));
            if (newData != null)
            {
                return new DataResponse<CartQuery>(_mapper.Map<CartQuery>(newData), 200, "Thêm giỏ hàng thành công");
            }
            throw new ApiException(400, "Thêm mới không thành công");
        }

        public DataResponse<CartQuery> Delete(long id)
        {
            var data = _cartRepository.Delete(id);
            if (data != null)
            {
                return new DataResponse<CartQuery>(_mapper.Map<CartQuery>(data), 200, "Xóa thông tin thành công");
            }
            throw new ApiException(400, "Xóa không thành công");
        }

        public DataResponse<CartQuery> GetById(long id)
        {
            var item = _cartRepository.GetById(id);
            if (item == null)
            {
                throw new ApiException(404, "Không tìm thấy thông tin");
            }
            return new DataResponse<CartQuery>(_mapper.Map<CartQuery>(item), 200, "Thành công");
        }

        public PagedDataResponse<CartFruit> Items(CommonListQuery commonList, long id)
        {
            var carts = _mapper.Map<List<CartQuery>>(_cartRepository.GetAll().Where(x => x.UserId == id));
            var fruits = _mapper.Map<List<FruitQuery>>(_fruitRepository.GetAll());
            var query = from cart in carts
                        join
                       fruit in fruits on cart.FruitId equals fruit.FruitId
                        select new CartFruit 
                        {
                            CartId=cart.CartId,
                            FruitId=cart.FruitId,
                            FruitImg=fruit.FruitImg,
                            FruitName=fruit.FruitName,
                            FruitPrice=fruit.FruitPrice,
                            Quantity=cart.Quantity,
                            UserId = cart.UserId
                        };
            var paginatedResult = PaginatedList<CartFruit>.ToPageList(query.ToList(), commonList.page, commonList.limit);
            return new PagedDataResponse<CartFruit>(paginatedResult, 200, query.Count());
        }

       /* public PagedDataResponse<CartQuery> Items(CommonListQuery commonList, long id)
        {
            var query = _mapper.Map<List<CartQuery>>(_cartRepository.GetAll().Where(x=>x.UserId==id));
            var fruits = _mapper.Map<List<FruitQuery>>(_fruitRepository.GetAll());
            var paginatedResult = PaginatedList<CartQuery>.ToPageList(query, commonList.page, commonList.limit);
            return new PagedDataResponse<CartQuery>(paginatedResult, 200, query.Count());
        }*/

        public DataResponse<CartQuery> Update(CartDto dto)
        {
            var item = _cartRepository.GetById(dto.CartId);
            if (item == null)
            {
                throw new ApiException(404, "Không tìm thấy thông tin");
            }
            var newData = _cartRepository.Update(_mapper.Map(dto, item));
            if (newData != null)
            {
                return new DataResponse<CartQuery>(_mapper.Map<CartQuery>(newData), 200, "Cập nhập thành công");
            }
            throw new ApiException(400, "Cập nhập thất bại");
        }
    }
}
