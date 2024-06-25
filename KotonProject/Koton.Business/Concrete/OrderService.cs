using AutoMapper;
using Koton.Business.Abstract;
using Koton.Business.DTO_s;
using Koton.DAL.Abstract;
using Koton.Entities.Models;
using Koton.Shared;


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
            orderDto.PaymentId = 1;
            var order = _mapper.Map<Order>(orderDto);
            order.OrderTotalPrice = orderDto.Items.Sum(x => x.SalesPrice);

            var result = await _orderRepository.AddAsync(order);

            var orderDetail = _mapper.Map<IEnumerable<OrderDetail>>(orderDto.Items);
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
           return await _orderRepository.GetAllAsync();
        }

        public async Task<Order> GetOrderById(int Id)
        {
            return await _orderRepository.GetByIdAsync(Id);        
        }

        public async Task<Order> UpdateOrder(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            await _orderRepository.UpdateAsync(order);  
            return order;
        }
    }
}
