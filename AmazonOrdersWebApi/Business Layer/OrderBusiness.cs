using Data_Access_Layer;
using Domain_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class OrderBusiness : IOrderBusiness
    {
        private readonly IOrderRepository _amazonRepository;

        public OrderBusiness(IOrderRepository amazonRepository)
        {
            _amazonRepository = amazonRepository;
        }

        public async Task<List<OrderDto>> GetAllOrders()
        {
            return await _amazonRepository.GetAllOrders();
        }

        public async Task<OrderDto> GetOrderById(int Id)
        {
            return await _amazonRepository.GetOrderById(Id);
        }

        public async Task InsertOrder(OrderDto amazonOrders)
        {
            await _amazonRepository.InsertOrder(amazonOrders);
            
        }

        public async Task UpdateOrder(OrderDto amazonOrders)
        {
            await _amazonRepository.UpdateOrder(amazonOrders);
        }

        public async Task DeleteOrderById(int Id)
        {
            await _amazonRepository.DeleteOrderById(Id);
        }
    }
}
