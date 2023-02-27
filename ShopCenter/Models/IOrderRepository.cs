namespace ShopCenter.Models
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
