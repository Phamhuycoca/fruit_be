using AutoMapper;
using onion_architecture.Application.Dto.Category;
using onion_architecture.Application.Dto.Store;
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
    public class StoreService:IStoreService
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public StoreService(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        public DataResponse<StoreQuery> Create(StoreDto dto)
        {
            var newData = _storeRepository.Create(_mapper.Map<Store>(dto));
            if (newData != null)
            {
                return new DataResponse<StoreQuery>(_mapper.Map<StoreQuery>(newData), 200, "Thêm mới thành công");
            }
            throw new ApiException(400, "Thêm mới không thành công");
        }

        public DataResponse<StoreQuery> Delete(long id)
        {
            var data = _storeRepository.Delete(id);
            if (data != null)
            {
                return new DataResponse<StoreQuery>(_mapper.Map<StoreQuery>(data), 200, "Xóa thông tin thành công");
            }
            throw new ApiException(400, "Xóa không thành công");
        }

        public DataResponse<StoreQuery> GetById(long id)
        {
            var item = _storeRepository.GetById(id);
            if (item == null)
            {
                throw new ApiException(404, "Không tìm thấy thông tin");
            }
            return new DataResponse<StoreQuery>(_mapper.Map<StoreQuery>(item), 200, "Thành công");
        }

        public PagedDataResponse<StoreQuery> Items(CommonListQuery commonList)
        {
            var query = _mapper.Map<List<StoreQuery>>(_storeRepository.GetAll());
            if (!string.IsNullOrEmpty(commonList.keyword))
            {
                query = query.Where(x => x.StoreName.Contains(commonList.keyword)).ToList();
            }
            var paginatedResult = PaginatedList<StoreQuery>.ToPageList(query, commonList.page, commonList.limit);
            return new PagedDataResponse<StoreQuery>(paginatedResult, 200, query.Count());
        }

        public DataResponse<StoreQuery> Update(StoreDto dto)
        {
            var item = _storeRepository.GetById(dto.StoreId);
            if (item == null)
            {
                throw new ApiException(404, "Không tìm thấy thông tin");
            }
            var newData = _storeRepository.Update(_mapper.Map(dto, item));
            if (newData != null)
            {
                return new DataResponse<StoreQuery>(_mapper.Map<StoreQuery>(newData), 200, "Cập nhập thành công");
            }
            throw new ApiException(400, "Cập nhập thất bại");
        }
    }
}
