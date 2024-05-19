using onion_architecture.Application.Dto.Dashboard;
using onion_architecture.Application.Dto.Fruit;
using onion_architecture.Application.IService;
using onion_architecture.Application.Wrappers.Abstract;
using onion_architecture.Application.Wrappers.Concrete;
using onion_architecture.Domain.Entity;
using onion_architecture.Domain.Repositories;
using onion_architecture.Infrastructure.Migrations;
using onion_architecture.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion_architecture.Application.Service
{
    public class DashboardService : IDashboardService
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IBillRepository _billRepository;
        private readonly IFruitRepository _fruitRepository;
        private readonly IBill_DetailRepository _billDetailRepository;
        public DashboardService(IStoreRepository storeRepository, IBillRepository billRepository, IFruitRepository fruitRepository, IBill_DetailRepository billDetailRepository)
        {
            _storeRepository = storeRepository;
            _billRepository = billRepository;
            _fruitRepository = fruitRepository;
            _billDetailRepository = billDetailRepository;
        }

        public DataResponse<Bill_Dashboard> BillDashboard()
        {
            var bill = new Bill_Dashboard()
            {
                Bill_Count= _billRepository.GetAll().Count(),
                don_hang_chua_thanh_toan= _billRepository.GetAll().Where(x => x.Bill_Status == 0).Count(),
                don_hang_dang_giao = _billRepository.GetAll().Where(x => x.Bill_Status == 1).Count(),
                don_hang_da_giao= _billRepository.GetAll().Where(x => x.Bill_Status == 2).Count(),
            };
            return new DataResponse<Bill_Dashboard>(bill, HttpStatusCode.OK, HttpStatusMessages.OK);

        }

        public DataResponse<List<Store_Dashboard>> StoreDashboard()
        {
            var stores = _storeRepository.GetAll();
            var fruits = _fruitRepository.GetAll();
            var bill_details = _billDetailRepository.GetAll();
            var list = new List<Store_Dashboard>();
            foreach (var store in stores)
            {
                var bill_detail=_billDetailRepository.GetAll().Where(x=>x.StoreId==store.StoreId).FirstOrDefault();
                if(bill_detail != null)
                {
                    var bills = _billRepository.GetAll().Where(x => x.BillId == bill_detail.BillId);
                    var storeDashboar = new Store_Dashboard()
                    {
                        StoreId = store.StoreId,
                        StoreName = store.StoreName,
                        Revenue = bills.Sum(x => long.Parse(x.Total_amount)),
                    };
                    list.Add(storeDashboar);
                }
                else
                {
                    var bills = _billRepository.GetAll().Where(x => x.BillId == bill_detail.BillId);
                    var storeDashboar = new Store_Dashboard()
                    {
                        StoreId = store.StoreId,
                        StoreName = store.StoreName,
                        Revenue = 0,
                    };
                    list.Add(storeDashboar);

                }

            }
            return new DataResponse<List<Store_Dashboard>>(list, HttpStatusCode.OK, HttpStatusMessages.OK);
        }

        public DataResponse<Totals> TotalDashboard()
        {
            var total=new Totals()
            { 
                bill_count= _billRepository.GetAll().Sum(x => long.Parse(x.Total_amount)),
                fruit_count= _billDetailRepository.GetAll().Select(x => x.FruitId).Count()
            };
            return new DataResponse<Totals>(total, HttpStatusCode.OK, HttpStatusMessages.OK);

        }
    }
}
