using onion_architecture.Application.Dto.Bill_Detail;
using onion_architecture.Application.Dto.Dashboard;
using onion_architecture.Application.Wrappers.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion_architecture.Application.IService
{
    public interface IDashboardService
    {
        DataResponse<List<Store_Dashboard>> StoreDashboard();
        DataResponse<Bill_Dashboard> BillDashboard();

    }
}
