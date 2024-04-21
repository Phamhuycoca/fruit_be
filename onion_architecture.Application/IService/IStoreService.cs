using onion_architecture.Application.Dto.Category;
using onion_architecture.Application.Dto.Store;
using onion_architecture.Application.Helper;
using onion_architecture.Application.Wrappers.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion_architecture.Application.IService
{
    public interface IStoreService
    {
        PagedDataResponse<StoreQuery> Items(CommonListQuery commonList);
        DataResponse<StoreQuery> Create(StoreDto dto);
        DataResponse<StoreQuery> Update(StoreDto dto);
        DataResponse<StoreQuery> Delete(long id);
        DataResponse<StoreQuery> GetById(long id);
    }
}
