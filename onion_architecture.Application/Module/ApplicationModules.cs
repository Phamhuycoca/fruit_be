﻿using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using onion_architecture.Infrastructure.Module;
using onion_architecture.Application.Mapping;
using onion_architecture.Application.IService;
using onion_architecture.Application.Service;
using FluentValidation;
using onion_architecture.Application.Common.ZaloPay;
using onion_architecture.Application.Dto;

namespace onion_architecture.Application.Module
{
    public static class ApplicationModules
    {
        public static IServiceCollection AddApplicationModules(this IServiceCollection services)
        {
            var assm = Assembly.GetExecutingAssembly();
            services.AddValidatorsFromAssembly(assm);
            services.AddInfrastructureModule();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IFruitService, FruitService>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IPaymentsService, PaymentsService>();
            services.AddScoped<IBillService, BillService>();
            services.AddScoped<IBill_DetailService, Bill_DetailService>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddSingleton<List<PaymentsItem>>();

            return services;
        }
    }
}
