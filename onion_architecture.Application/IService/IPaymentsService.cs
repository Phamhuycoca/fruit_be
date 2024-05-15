using onion_architecture.Application.Dto;
using onion_architecture.Application.Dto.Bill;
using onion_architecture.Application.Helper;
using onion_architecture.Application.Wrappers.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion_architecture.Application.IService
{
    public interface IPaymentsService
    {
        PagedDataResponse<PaymentsItem> Items(CommonListQuery commonList);
        List<PaymentsItem> CartItems();
        DataResponse<PaymentsItem> Payments(PaymentsItem dto);
        DataResponse<PaymentsItem> Remove(long id);
        bool RemoveAll();
    }
}
