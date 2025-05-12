using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NuevoProyecto.API.src.Core.Entities;
using NuevoProyecto.API.src.Application.DTOs;
using NuevoProyecto.API.src.Core.Interfaces;
using NuevoProyecto.API.src.Application.Mappings;



namespace NuevoProyecto.API.src.Application.Services
{
    public class OrderService: GenericService<Order, OrderDto, OrderCreateDto>, IOrderService
    {
        
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
         public OrderService(
            IGenericRepository<Order> genericRepository,
            IOrderRepository orderRepository,
            IProductRepository productRepository,
            IMapper mapper
        ) : base(genericRepository, mapper)
         {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersByUserIdAsync(int userId)
        {
            var orders = await _orderRepository.GetOrdersByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public override async Task<OrderDto> AddAsync(OrderCreateDto orderCreateDto)
            {
                // Create a new order
                var order = new Order
                {
                    UserId = orderCreateDto.UserId,
                    Status = "Pending",
                    TotalAmount = 0
                };

                // Create order items and calculate total
                var orderItems = new List<OrderItem>();
                decimal totalAmount = 0;

                foreach (var item in orderCreateDto.Items)
                {
                    var product = await _productRepository.GetByIdAsync(item.ProductId);
                    if (product == null)
                        throw new ArgumentException($"Product with ID {item.ProductId} does not exist.");

                    if (product.Stock < item.Quantity)
                        throw new ArgumentException($"Not enough stock for product {product.Name}.");

                    var orderItem = new OrderItem
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        PriceAtTime = product.Price
                    };

                    orderItems.Add(orderItem);
                    totalAmount += product.Price * item.Quantity;

                    // Update product stock
                    product.Stock -= item.Quantity;
                    await _productRepository.UpdateAsync(product);
                }

                order.TotalAmount = totalAmount;
                order.OrderItems = orderItems;

                await _repository.AddAsync(order);
                return _mapper.Map<OrderDto>(order);
            }

    }
}