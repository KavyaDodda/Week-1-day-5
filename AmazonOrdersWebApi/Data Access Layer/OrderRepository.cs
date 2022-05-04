using Data_Access_Layer.Models;
using Domain_Layer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class OrderRepository : IOrderRepository
    {
        public async Task<List<OrderDto>> GetAllOrders()
        {

            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var orderDto = await dbContext.Orders.ToListAsync();

                List<OrderDto> domainModels = new List<OrderDto>();
                foreach (var ord in orderDto)
                {
                    domainModels.Add(new OrderDto
                    {
                        Id = ord.Id,
                        UserName = ord.UserName,
                        Cost = (int)ord.Cost,
                        ItemQty = ord.ItemQty,
                        CreatedDate = ord.CreatedDate,
                        UpdatedDate = (DateTime)ord.UpdatedDate,
                        AmazonId = ord.AmazonId
                    });
                }
                return domainModels;
            }
        }

        public async Task InsertOrder(OrderDto amazonOrders)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var dbModel = new Order
                {
                    UserName = amazonOrders.UserName,
                    Cost = amazonOrders.Cost,
                    ItemQty = amazonOrders.ItemQty,
                    CreatedDate = amazonOrders.CreatedDate,
                    UpdatedDate = amazonOrders.UpdatedDate,
                    AmazonId = amazonOrders.AmazonId
                };

                dbContext.Orders.Add(dbModel);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateOrder(OrderDto orderDto)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var findOrder = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == orderDto.Id);

                findOrder.UserName = orderDto.UserName;
                findOrder.Cost = orderDto.Cost;
                findOrder.ItemQty = orderDto.ItemQty;

                dbContext.Orders.Update(findOrder);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteOrderById(int Id)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var findOrder = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == Id);
                dbContext.Orders.Remove(findOrder);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<OrderDto> GetOrderById(int id)
        {

            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var orderDto = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);

                OrderDto domainModel = new OrderDto
                {
                    AmazonId = orderDto.AmazonId,
                    UserName = orderDto.UserName,
                    Cost = (int)orderDto.Cost,
                    ItemQty = (int)orderDto.Cost,
                    CreatedDate = orderDto.CreatedDate,
                    UpdatedDate=(DateTime)orderDto.UpdatedDate,
                };

                return domainModel;
            }
        }

    }
}


