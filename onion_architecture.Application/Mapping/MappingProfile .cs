using AutoMapper;
using onion_architecture.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using onion_architecture.Application.Features.Dto.UserDto;
using onion_architecture.Application.Dto.Category;
using onion_architecture.Application.Dto.Fruit;
using onion_architecture.Application.Features.Auth;
using onion_architecture.Application.Dto.Store;
using onion_architecture.Application.Dto.Cart;
using onion_architecture.Application.Dto.Bill;
using onion_architecture.Application.Dto.Bill_Detail;

namespace onion_architecture.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //User
            CreateMap<User, CreateUser>().ReverseMap();
            CreateMap<User, UpdateUser>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, RegisterDto>().ReverseMap();
            CreateMap<Refresh_Token, Refresh_TokenDto>().ReverseMap();



            CreateMap<Category, CategoryCreate>().ReverseMap();
            CreateMap<Category, CategoryQuery>().ReverseMap();

            CreateMap<Fruit,FruitQuery>().ReverseMap();
            CreateMap<Fruit,FruitCreate>().ReverseMap();

            CreateMap<Store,StoreDto>().ReverseMap();
            CreateMap<Store,StoreQuery>().ReverseMap();

            CreateMap<Cart, CartQuery>().ReverseMap();
            CreateMap<Cart, CartDto>().ReverseMap();
            CreateMap<Cart, CartFruit>().ReverseMap();

            CreateMap<Bill, BillDto>().ReverseMap();
            CreateMap<Bill, BillQuery>().ReverseMap();

            CreateMap<Bill_Detail,Bill_DetailDto>().ReverseMap();
            CreateMap<Bill_Detail,Bill_DetailQuery>().ReverseMap();


        }
    }
}
