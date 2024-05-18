using onion_architecture.Application.Dto.Bill;
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
    public interface IBillService
    {
        PagedDataResponse<BillQuery> Items(CommonListQuery commonList,long id);
        DataResponse<BillQuery> Create(BillDto dto);
        DataResponse<BillQuery> Update(BillDto dto);
        DataResponse<BillQuery> Delete(long id);
        DataResponse<BillQuery> GetById(long id);
        PagedDataResponse<BillQuery> ItemsStatus0(CommonListQuery commonList);

    }
}
