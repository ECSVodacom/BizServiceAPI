using BizServiceApi.Database.Repository;
using BizServiceApi.Database.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection.PortableExecutable;

namespace Adaptris.Api.Repository
{
    public class Gateway
    {
        private readonly DbContextOptions<TransformationDbContext> _context;

        public Gateway(DbContextOptions<TransformationDbContext> context)
        {
            _context = context;
        }

        public AdaptrisOrderHeader? GetOrder(string orderNumber, string sender, string receiver, string deliveryPoint)
        {
            using var context = new TransformationDbContext(_context);
            var order = context.AdaptrisOrderHeaders.FirstOrDefault(o =>
                o.OrderNumber == orderNumber &&
                o.Sender == receiver &&
                o.Receiver == sender &&
                o.DeliveryPoint == deliveryPoint);

            if (order != null)
            {
                order.AdaptrisOrderLines = context.AdaptrisOrderLines.Where(ol => ol.OrderHeaderId == order.Id).ToArray();
            }

            return order;
        }

        internal void UpdateOrder(AdaptrisOrderHeader existingOrder, string responseDocNumber)
        {
            using var context = new TransformationDbContext(_context);

            existingOrder.Status = "Responded";
            existingOrder.ResponseDocNumber = responseDocNumber;
            existingOrder.ResponseDate = DateTime.Now;
            context.AdaptrisOrderHeaders.Update(existingOrder);
            context.SaveChanges();
        }
    }
}
