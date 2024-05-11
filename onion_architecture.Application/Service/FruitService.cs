using AutoMapper;
using CloudinaryDotNet;
using onion_architecture.Application.Dto.Category;
using onion_architecture.Application.Dto.Fruit;
using onion_architecture.Application.Dto.Store;
using onion_architecture.Application.Helper;
using onion_architecture.Application.IService;
using onion_architecture.Application.Wrappers.Concrete;
using onion_architecture.Domain.Entity;
using onion_architecture.Domain.Repositories;
using onion_architecture.Infrastructure.Exceptions;
using onion_architecture.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion_architecture.Application.Service
{
    public class FruitService : IFruitService
    {
        private readonly IFruitRepository _fruitRepository;
        private readonly IMapper _mapper;
        private readonly Cloudinary _cloudinary;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IStoreRepository _storeRepository;
        public FruitService(IFruitRepository fruitRepository, IMapper mapper,Cloudinary cloudinary, ICategoryRepository categoryRepository, IStoreRepository storeRepository)
        {
            _fruitRepository = fruitRepository;
            _mapper = mapper;
            _cloudinary = cloudinary;
            _categoryRepository = categoryRepository;
            _storeRepository = storeRepository;
        }

        public DataResponse<FruitQuery> Create(FruitCreate dto)
        {
            UpLoadImage upload = new UpLoadImage(_cloudinary);
            if(dto.fileImg != null)
            {
                dto.FruitImg = upload.ImageUpload(dto.fileImg);
            }           
            else
            {
                throw new ApiException(HttpStatusCode.BAD_REQUEST, "Vui lòng chọn hình ảnh");
            }
            if (dto.Discount != null || dto.Discount=="0")
            {
                var price = double.Parse(dto.FruitPrice) - (double.Parse(dto.FruitPrice)*(double.Parse(dto.Discount)/100));
                dto.PriceDiscount = price.ToString();
            }
            var newData = _fruitRepository.Create(_mapper.Map<Fruit>(dto));
            if (newData != null)
            {
                return new DataResponse<FruitQuery>(_mapper.Map<FruitQuery>(newData), HttpStatusCode.OK, HttpStatusMessages.AddedSuccesfully);
            }
            throw new ApiException(HttpStatusCode.BAD_REQUEST, HttpStatusMessages.AddedError);

        }

        public DataResponse<FruitQuery> Delete(long id)
        {
            var item = _fruitRepository.GetById(id);
            if (item == null)
            {
                throw new ApiException(HttpStatusCode.ITEM_NOT_FOUND, HttpStatusMessages.NotFound);
            }
            var data = _fruitRepository.Delete(id);
            if (data != null)
            {
                return new DataResponse<FruitQuery>(_mapper.Map<FruitQuery>(item), HttpStatusCode.OK, HttpStatusMessages.DeletedSuccessfully);
            }
            throw new ApiException(HttpStatusCode.BAD_REQUEST, HttpStatusMessages.DeletedError);
        }

        public DataResponse<FruitQuery> GetById(long id)
        {
            var item = _fruitRepository.GetById(id);
            if (item == null)
            {
                throw new ApiException(HttpStatusCode.ITEM_NOT_FOUND, HttpStatusMessages.NotFound);
            }
            return new DataResponse<FruitQuery>(_mapper.Map<FruitQuery>(item), HttpStatusCode.OK, HttpStatusMessages.OK);
        }

        public PagedDataResponse<FruitQuery> Items(CommonListQuery commonList)
        {
            var fruits = _mapper.Map<List<FruitQuery>>(_fruitRepository.GetAll());
            var categories=_mapper.Map<List<CategoryQuery>>(_categoryRepository.GetAll());
            var stores = _mapper.Map<List<StoreQuery>>(_storeRepository.GetAll());
            var query = from fruit in fruits
                        join
                       category in categories on fruit.CategoriesId equals category.CategoriesId
                       join 
                       store in stores on fruit.StoreId equals store.StoreId
                        select
                       new FruitQuery
                       {
                           CategoriesId=category.CategoriesId,
                           CategoriesName=category.CategoriesName,
                           Discount=fruit.Discount,
                           FruitDescription=fruit.FruitDescription,
                           FruitId=fruit.FruitId,
                           FruitImg=fruit.FruitImg,
                           FruitName=fruit.FruitName,
                           FruitQuantity=fruit.FruitQuantity,
                           FruitPrice=fruit.FruitPrice,
                           PriceDiscount=fruit.PriceDiscount,
                           createdAt=fruit.createdAt,
                           createdBy=fruit.createdBy,
                           deletedAt=fruit.deletedAt,
                           deletedBy=fruit.deletedBy,   
                           IsDelete=fruit.IsDelete,
                           updatedAt=fruit.updatedAt,
                           updatedBy=fruit.updatedBy,
                           StoreId=fruit.StoreId,
                           StoreName=store.StoreName
                       };
            if (!string.IsNullOrEmpty(commonList.keyword))
            {
                query = query.Where(x => x.FruitName.Contains(commonList.keyword)||
                x.FruitQuantity.Contains(commonList.keyword)
                ).ToList();
            }
            var paginatedResult = PaginatedList<FruitQuery>.ToPageList(query.ToList(), commonList.page, commonList.limit);
            return new PagedDataResponse<FruitQuery>(paginatedResult, 200, query.Count());
        }

        public PagedDataResponse<FruitQuery> Product(CommonListQueryProducts commonList)
        {
            var fruits = _mapper.Map<List<FruitQuery>>(_fruitRepository.GetAll());
            var categories = _mapper.Map<List<CategoryQuery>>(_categoryRepository.GetAll());
            var stores = _mapper.Map<List<StoreQuery>>(_storeRepository.GetAll());
            var query = from fruit in fruits
                        join
                       category in categories on fruit.CategoriesId equals category.CategoriesId
                        join
                        store in stores on fruit.StoreId equals store.StoreId
                        select
                       new FruitQuery
                       {
                           CategoriesId = category.CategoriesId,
                           CategoriesName = category.CategoriesName,
                           Discount = fruit.Discount,
                           FruitDescription = fruit.FruitDescription,
                           FruitId = fruit.FruitId,
                           FruitImg = fruit.FruitImg,
                           FruitName = fruit.FruitName,
                           FruitQuantity = fruit.FruitQuantity,
                           FruitPrice = fruit.FruitPrice,
                           PriceDiscount = fruit.PriceDiscount,
                           createdAt = fruit.createdAt,
                           createdBy = fruit.createdBy,
                           deletedAt = fruit.deletedAt,
                           deletedBy = fruit.deletedBy,
                           IsDelete = fruit.IsDelete,
                           updatedAt = fruit.updatedAt,
                           updatedBy = fruit.updatedBy,
                           StoreId = fruit.StoreId,
                           StoreName = store.StoreName
                       };
            if (!string.IsNullOrEmpty(commonList.keyword))
            {
                query = query.Where(x => x.FruitName.Contains(commonList.keyword) ||
                x.FruitQuantity.Contains(commonList.keyword)||
                x.FruitPrice.Contains(commonList.keyword)
                ).ToList();
            }
            if(!string.IsNullOrEmpty(commonList.sale))
            {
                if (commonList.sale == "Đang giảm giá")
                {
                    query = query.Where(x => x.Discount != "0");
                }
                else
                {
                    query = query.Where(x => x.Discount == "0");
                }
            }
            if (!string.IsNullOrEmpty(commonList.price))
            {
                if (commonList.price == "Từ thấp đến cao")
                {
                    query = query.OrderBy(x=>x.FruitPrice);
                }
                else if(commonList.price == "Từ cao đến thấp")
                {
                    query = query.OrderByDescending(x=>x.FruitPrice);
                }
            }
           
            if (!string.IsNullOrEmpty(commonList.CategoriesId.ToString()))
            {
                query = query.Where(x => x.CategoriesId == commonList.CategoriesId);
            }
                var paginatedResult = PaginatedList<FruitQuery>.ToPageList(query.ToList(), commonList.page, commonList.limit);
            return new PagedDataResponse<FruitQuery>(paginatedResult, 200, query.Count());
        }

        public DataResponse<FruitQuery> Update(FruitCreate dto)
        {
            UpLoadImage upload = new UpLoadImage(_cloudinary);
            var item = _fruitRepository.GetById(dto.FruitId);
            if (dto.fileImg != null)
            {
                if (item.FruitImg != null)              
                {
                    upload.DeleteImage(item.FruitImg);
                }
                dto.FruitImg = upload.ImageUpload(dto.fileImg);
            }
            else
            {
                dto.FruitImg = item.FruitImg;
            }
            if (dto.Discount != null || dto.Discount == "0")
            {
                var price = double.Parse(dto.FruitPrice) - (double.Parse(dto.FruitPrice) * (double.Parse(dto.Discount) / 100));
                dto.PriceDiscount = price.ToString();
            }
            var newData = _fruitRepository.Update(_mapper.Map(dto, item));
            if (newData != null)
            {
                return new DataResponse<FruitQuery>(_mapper.Map<FruitQuery>(newData), HttpStatusCode.OK, HttpStatusMessages.AddedSuccesfully);
            }
            throw new ApiException(HttpStatusCode.BAD_REQUEST, HttpStatusMessages.AddedError);
        }
    }
}
