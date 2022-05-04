using Domain_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public interface IOrderBusiness
    {
        public Task<List<OrderDto>> GetAllOrders();
        public Task<OrderDto> GetOrderById(int Id);
        public Task InsertOrder(OrderDto orderDto);
        public Task UpdateOrder(OrderDto orderDto);
        public Task DeleteOrderById(int Id);



    }
}