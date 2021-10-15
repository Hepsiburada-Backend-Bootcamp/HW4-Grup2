using HW4_Grup2.Domain.Entities;

namespace HW4_Grup2.Application.ServiceInterfaces
{
    public interface IOrderDetailService
    {
        void InsertOrderDetailToMongoDb(OrderDetail orderDetail);
    }
}
