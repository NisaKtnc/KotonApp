using AutoMapper;
using Koton.Business.Abstract;
using Koton.Business.DTO_s;
using Koton.DAL.Abstract;
using Koton.Entities.Models;
using Koton.Shared;
using Microsoft.EntityFrameworkCore;


namespace Koton.Business.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;
        private readonly SharedIdentity _identity;
        public OrderService(IOrderRepository orderRepository, IMapper mapper, IOrderDetailRepository orderDetailRepository, SharedIdentity identity)
        {
            this._orderRepository = orderRepository;
            this._mapper = mapper;
            _orderDetailRepository = orderDetailRepository;
            _identity = identity;
        }

        public async Task<Order> AddOrder(OrderDto orderDto)
        {
            orderDto.CustomerId = Convert.ToInt32(_identity.UserId);
            orderDto.PaymentId = 2;
            var order = _mapper.Map<Order>(orderDto);
            Order result;
            try
            {
                result = await _orderRepository.AddAsync(order);

            }
            catch (Exception ex)
            {

                throw;
            }

            var orderDetails = new List<OrderDetailDto>();
            foreach (var item in orderDto.Basket.BasketItems)
            {
                orderDetails.Add(new OrderDetailDto
                {
                    OrderId = result.Id,
                    ProductId= item.ProductId,
                    Quantity = item.Count,
                    SalesPrice = item.Price,
                    ShippingCost = 100,
                    UnitPrice= item.Price,
                    
                });

            };

            var orderDetail = _mapper.Map<List<OrderDetail>>(orderDetails);
            await _orderDetailRepository.AddBulkAsync(orderDetail);

            return order;
        }

        public async Task<Order> DeleteOrderById(int Id)
        {
            var order = await _orderRepository.GetByIdAsync(Id);
            if (order == null)
            
                throw new Exception("Order is not found");
                await _orderRepository.DeleteAsync(order);
                return order;
            
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
           return await _orderRepository.GetAllAsync2(x=> x.Include(x=> x.OrderDetails).ThenInclude(x=> x.Product));
        }

        public async Task<Order> GetOrderById(int Id)
        {
            return await _orderRepository.GetByIdAsync2(Id, x => x.Include(x => x.OrderDetails).ThenInclude(x => x.Product).ThenInclude(x=> x.Files));
        }

        public async Task<Order> UpdateOrder(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            await _orderRepository.UpdateAsync(order);  
            return order;
        }
    }
}
