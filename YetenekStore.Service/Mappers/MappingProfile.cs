﻿using AutoMapper;
using YetenekStore.Models.Dtos.Categories;
using YetenekStore.Models.Dtos.OrderItems;
using YetenekStore.Models.Dtos.Orders;
using YetenekStore.Models.Dtos.Products;
using YetenekStore.Models.Dtos.Users;
using YetenekStore.Models.Entities;

namespace YetenekStore.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterRequestDto, User>();
        CreateMap<User, UserResponseDto>();


        CreateMap<ProductAddRequestDto, Product>();
        CreateMap<ProductUpdateRequestDto, Product>();
        CreateMap<Product, ProductResponseDto>();

        CreateMap<Category, CategoryResponseDto>();
        CreateMap<CategoryAddRequestDto, Category>();
        CreateMap<CategoryUpdateRequestDto, Category>();


        CreateMap<Order, OrderResponseDto>();
        CreateMap<OrderAddRequestDto, Order>();
        CreateMap<OrderUpdateRequestDto, Order>();

        CreateMap<OrderItem, OrderItemResponseDto>();
    }
}