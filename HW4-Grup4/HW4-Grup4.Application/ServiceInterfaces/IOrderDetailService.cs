using HW4_Grup4.Domain.Entities;

namespace HW4_Grup4.Application.ServiceInterfaces
{
    public interface IOrderDetailService
    {
        void InsertOrderDetailToMongoDb(OrderDetail orderDetail);
    }
}
