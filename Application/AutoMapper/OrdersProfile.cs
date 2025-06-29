using AutoMapper;
using Domain.Commands;
using Domain.Dtos.CreateOrder;
using Domain.Entities;
using Domain.Queries;

namespace Application.AutoMapper
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            CreateMap<Models.Orders.CreateOrder.OrderModel, CreateOrderCommand>()
                .ForCtorParam(nameof(CreateOrderCommand.CustomerId), opt => opt.MapFrom(src => src.CustomerId))
                .ForCtorParam(nameof(CreateOrderCommand.OrderItems), opt => opt.MapFrom(src => src.Items));

            CreateMap<Models.Orders.CreateOrder.OrderItemModel, OrderItemDto>();

            CreateMap<Models.Orders.GetOrders.GetOrdersModel, GetOrdersQuery>()
                .ForCtorParam(nameof(GetOrdersQuery.CustomerId), opt => opt.MapFrom(src => src.CustomerId))
                .ForCtorParam(nameof(GetOrdersQuery.LoadItems), opt => opt.MapFrom(src => src.LoadItems))
                .ForCtorParam(nameof(GetOrdersQuery.SkipCount), opt => opt.MapFrom(src => src.SkipCount))
                .ForCtorParam(nameof(GetOrdersQuery.TakeCount), opt => opt.MapFrom(src => src.TakeCount));

            CreateMap<Order, Models.Orders.GetOrders.OrderModel>()
                .ForMember(dst => dst.Items, opt => opt.MapFrom(src => src.OrderItems))
                .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.OrderStatus));

            CreateMap<OrderItem, Models.Orders.GetOrders.OrderItemModel>();

            CreateMap<Product, Models.Orders.GetOrders.ProductModel>()
                .ForMember(dst => dst.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName));
        }
    }
}
