using onion_architecture.Application.Dto.Bill_Detail;
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
    public interface IBill_DetailService
    {
        PagedDataResponse<Bill_DetailQuery> Items(CommonListQuery commonList);
        DataResponse<Bill_DetailQuery> Create(Bill_DetailDto dto);
        DataResponse<Bill_DetailQuery> Update(Bill_DetailDto dto);
        DataResponse<Bill_DetailQuery> Delete(long id);
        DataResponse<Bill_DetailQuery> GetById(long id);
    }
}
