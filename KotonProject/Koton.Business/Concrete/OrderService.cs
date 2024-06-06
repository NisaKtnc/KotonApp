using AutoMapper;
using Koton.Business.Abstract;
using Koton.Business.DTO_s;
using Koton.DAL.Abstract;
using Koton.Entities.Models;


namespace Koton.Business.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper, IOrderDetailRepository orderDetailRepository)
        {
            this._orderRepository = orderRepository;
            this._mapper = mapper;
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<Order> AddOrder(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            order.OrderTotalPrice = orderDto.Items.Sum(x => x.SalesPrice);
            var result = await _orderRepository.AddAsync(order);

            var items = orderDto.Items.All(c => { c.OrderId = result.Id; return true; });
            var orderDetail = _mapper.Map<List<OrderDetail>>(orderDto.Items);
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
