using AutoMapper;
using onion_architecture.Application.Dto.Bill;
using onion_architecture.Application.Dto.Category;
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
    public class BillService : IBillService
    {
        private readonly IBillRepository _billRepository;
        private readonly IMapper _mapper;
        private readonly IBill_DetailRepository _billDetailRepository;

        public BillService(IBillRepository billRepository, IMapper mapper, IBill_DetailRepository billDetailRepository)
        {
            _billRepository = billRepository;
            _mapper = mapper;
            _billDetailRepository = billDetailRepository;
        }

        public DataResponse<BillQuery> Create(BillDto dto)
        {
            var newData = _billRepository.Create(_mapper.Map<Bill>(dto));
            if (newData != null)
            {
                return new DataResponse<BillQuery>(_mapper.Map<BillQuery>(newData), 200, "Thanh toán hóa đơn thành công");
            }
            throw new ApiException(400, "Thanh toán không thành công");
        }

        public DataResponse<BillQuery> Delete(long id)
        {
            throw new NotImplementedException();
        }

        public DataResponse<BillQuery> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public PagedDataResponse<BillQuery> Items(CommonListQuery commonList,long id)
        {
            var query = _mapper.Map<List<BillQuery>>(_billRepository.GetAll().Where(x=>x.UserId==id));
            var paginatedResult = PaginatedList<BillQuery>.ToPageList(query, commonList.page, commonList.limit);
            return new PagedDataResponse<BillQuery>(paginatedResult, 200, query.Count());
        }

        public PagedDataResponse<BillQuery> ItemsStatus0(CommonListQuery commonList)
        {
            var query = _mapper.Map<List<BillQuery>>(_billRepository.GetAll().Where(x => x.Bill_Status==0));
            var paginatedResult = PaginatedList<BillQuery>.ToPageList(query, commonList.page, commonList.limit);
            return new PagedDataResponse<BillQuery>(paginatedResult, 200, query.Count());
        }

        public DataResponse<BillQuery> Update(BillDto dto)
        {
            throw new NotImplementedException();
        }

        public DataResponse<List<BillQuery>> UpdateStatus()
        {
            var query = _mapper.Map<List<BillStatus>>(_billRepository.GetAll().Where(x => x.Bill_Status == 0));
            if (query == null)
            {
                throw new ApiException(404, "Không có dữ liệu cần duyệt");
            }
            var list=new List<BillQuery>();
            foreach(var item in query)
            {
                var data = _billRepository.GetById(item.BillId);
                item.Bill_Status = 1;
                var newData=_billRepository.Update(_mapper.Map(item,data));
                list.Add(_mapper.Map<BillQuery>(newData));
            }
            return new DataResponse<List<BillQuery>>(list, 200, "Thanh duyệt danh sách thành công");

        }
    }
}
