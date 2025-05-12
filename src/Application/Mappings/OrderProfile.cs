using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NuevoProyecto.API.src.Core.Entities;
using NuevoProyecto.API.src.Application.DTOs;

namespace NuevoProyecto.API.src.Application.Mappings
{
    public class OrderProfile: Profile
    {
         public OrderProfile()
        {
            // Mapeo de Order a OrderDto
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Users != null ? src.Users.UserName : string.Empty))
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems));

            // Mapeo de OrderCreateDto a Order
            CreateMap<OrderCreateDto, Order>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => "Pending"))
                .ForMember(dest => dest.OrderItems, opt => opt.Ignore()); // Los items se manejan en el servicio

            // Mapeo de OrderItem a OrderItemDto
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product != null ? src.Product.Name : string.Empty))
                .ForMember(dest => dest.Subtotal, opt => opt.MapFrom(src => src.Quantity * src.PriceAtTime));

            // Mapeo de OrderItemCreateDto a OrderItem
            CreateMap<OrderItemCreateDto, OrderItem>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.Order, opt => opt.Ignore())
                .ForMember(dest => dest.Product, opt => opt.Ignore());
        }
    }
}