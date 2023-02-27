namespace ShopCenter.Models
{
    public class OrderRepository :IOrderRepository
    {

        private readonly ShopDbContext _shopCenterDbContext;
        private readonly IShoppingCart _shoppingCart;
        public OrderRepository(ShopDbContext shopDbContext,IShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
            _shopCenterDbContext= shopDbContext;
        }
        public void CreateOrder(Order order)
        {
           order.OrderPlaced=DateTime.Now;
            List<ShoppingCartItem>? shoppingCartItems=_shoppingCart.ShoppingCartItems;
            order.OrderTotal=_shoppingCart.GetShoppingCartTotal();
            order.OrderDetails = new List<OrderDetail>();
          foreach(ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                        Amount =shoppingCartItem.Amount,
                        PieId=shoppingCartItem.Pie.PieId,
                        Price=shoppingCartItem.Pie.Price

                };
                order.OrderDetails.Add(orderDetail);
            }
            _shopCenterDbContext.Orders.Add(order);
            _shopCenterDbContext.SaveChanges();
        }

        //void IOrderRepository.CreateOrder(Order order)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
