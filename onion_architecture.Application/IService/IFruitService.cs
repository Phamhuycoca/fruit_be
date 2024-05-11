using onion_architecture.Application.Dto.Category;
using onion_architecture.Application.Dto.Fruit;
using onion_architecture.Application.Helper;
using onion_architecture.Application.Wrappers.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion_architecture.Application.IService
{
    public interface IFruitService
    {
        PagedDataResponse<FruitQuery> Items(CommonListQuery commonList);
        PagedDataResponse<FruitQuery> Product(CommonListQueryProducts commonList);
        DataResponse<FruitQuery> Create(FruitCreate dto);
        DataResponse<FruitQuery> Update(FruitCreate dto);
        DataResponse<FruitQuery> Delete(long id);
        DataResponse<FruitQuery> GetById(long id);
    }
}
