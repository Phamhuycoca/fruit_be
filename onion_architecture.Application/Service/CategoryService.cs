using AutoMapper;
using onion_architecture.Application.Dto.Category;
using onion_architecture.Application.Helper;
using onion_architecture.Application.IService;
using onion_architecture.Application.Wrappers.Concrete;
using onion_architecture.Domain.Entity;
using onion_architecture.Domain.Repositories;
using onion_architecture.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace onion_architecture.Application.Service
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public DataResponse<CategoryQuery> Create(CategoryCreate dto)
        {
            var newData = _categoryRepository.Create(_mapper.Map<Category>(dto));
            if (newData != null)
            {
                return new DataResponse<CategoryQuery>(_mapper.Map<CategoryQuery>(newData), 200, "Thêm mới thành công");
            }
            throw new ApiException(400,"Thêm mới không thành công");
        }

        public DataResponse<CategoryQuery> Delete(long id)
        {
            var data = _categoryRepository.Delete(id);
            if (data != null)
            {
                return new DataResponse<CategoryQuery>(_mapper.Map<CategoryQuery>(data), 200, "Xóa thông tin thành công");
            }
            throw new ApiException(400,"Xóa không thành công");
        }

        public DataResponse<CategoryQuery> GetById(long id)
        {
            var item = _categoryRepository.GetById(id);
            if (item == null)
            {
                throw new ApiException(404,"Không tìm thấy thông tin");
            }
            return new DataResponse<CategoryQuery>(_mapper.Map<CategoryQuery>(item), 200,"Thành công");
        }

        public PagedDataResponse<CategoryQuery> Items(CommonListQuery commonList)
        {
            var query = _mapper.Map<List<CategoryQuery>>(_categoryRepository.GetAll());
            if (!string.IsNullOrEmpty(commonList.keyword))
            {
                query = query.Where(x => x.CategoriesName.Contains(commonList.keyword)).ToList();
            }
            var paginatedResult = PaginatedList<CategoryQuery>.ToPageList(query, commonList.page, commonList.limit);
            return new PagedDataResponse<CategoryQuery>(paginatedResult, 200, query.Count());
        }

        public DataResponse<CategoryQuery> Update(CategoryCreate dto)
        {
            var item = _categoryRepository.GetById(dto.CategoriesId);
            if (item == null)
            {
                throw new ApiException(404,"Không tìm thấy thông tin");
            }
            var newData = _categoryRepository.Update(_mapper.Map(dto, item));
            if (newData != null)
            {
                return new DataResponse<CategoryQuery>(_mapper.Map<CategoryQuery>(newData), 200,"Cập nhập thành công");
            }
            throw new ApiException(400,"Cập nhập thất bại");
        }
    }
}
