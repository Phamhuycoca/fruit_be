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
    public interface ICategoryService
    {
        PagedDataResponse<CategoryQuery> Items(CommonListQuery commonList);      
        DataResponse<CategoryQuery> Create(CategoryCreate dto);
        DataResponse<CategoryQuery> Update(CategoryCreate dto);
        DataResponse<CategoryQuery> Delete(long id);
        DataResponse<CategoryQuery> GetById(long id);
    }
}
