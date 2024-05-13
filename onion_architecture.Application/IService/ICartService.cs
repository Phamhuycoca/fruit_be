using onion_architecture.Application.Dto.Cart;
using onion_architecture.Application.Dto.Category;
using onion_architecture.Application.Helper;
using onion_architecture.Application.Wrappers.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion_architecture.Application.IService
{
    public interface ICartService
    {
        PagedDataResponse<CartFruit> Items(CommonListQuery commonList,long id);
        //PagedDataResponse<CartFruit> Item(CommonListQuery commonList,long id);
        DataResponse<CartQuery> Create(CartDto dto);
        DataResponse<CartQuery> Update(CartDto dto);
        DataResponse<CartQuery> Delete(long id);
        DataResponse<CartQuery> GetById(long id);
        bool TangGiamCartItem(CartDto item);
    }
}
