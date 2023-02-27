using Microsoft.EntityFrameworkCore;

namespace ShopCenter.Models
{
    public class ShoppingCart : IShoppingCart

    {
        private readonly ShopDbContext _shopDbContext;
        public string? ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default;
        private ShoppingCart(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext; 
        }
        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;
            ShopDbContext context = services.GetService<ShopDbContext>() ?? throw new Exception("Error initializing");
            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();
            session?.SetString("CartId", cartId);
            return new ShoppingCart(context) { ShoppingCartId = cartId };

        }

        //private static Exception Exception(string v)
        //{
        //    throw new NotImplementedException();
        //}

        public void AddToCart(Pie pie)
        {
            var shoppingCartItem = _shopDbContext.ShoppingCartItems.SingleOrDefault(s => s.Pie.PieId == pie.PieId && s.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem == null) 
            {

                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Pie = pie,
                    Amount = 1
                };
                _shopDbContext.ShoppingCartItems.Add(shoppingCartItem);

            }
            else
            {
                shoppingCartItem.Amount++;

            }
            _shopDbContext.SaveChanges();

        }
        public int RemoveFromCart(Pie pie)
        {
            var shoppingCartItem= _shopDbContext.ShoppingCartItems.SingleOrDefault(
                s => s.Pie.PieId ==pie.PieId && s.ShoppingCartId==ShoppingCartId);
            var localAmount = 0;
            if(shoppingCartItem != null)
            {
                if(shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount =shoppingCartItem.Amount;   

                }
                else
                {
                    _shopDbContext.ShoppingCartItems.Remove(shoppingCartItem);


                }
            }
            _shopDbContext.SaveChanges();
            return localAmount;

        }
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??= 
                _shopDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId).Include(s => s.Pie).ToList();  

        }
        public void ClearCart()
        {
            var cartItems = _shopDbContext.ShoppingCartItems.Where(cart => cart.ShoppingCartId == ShoppingCartId);
            _shopDbContext.ShoppingCartItems.RemoveRange(cartItems);
            _shopDbContext.SaveChanges();

        }
        public decimal GetShoppingCartTotal()
        {
            var total =_shopDbContext.ShoppingCartItems.Where(c => 
            c.ShoppingCartId==ShoppingCartId).Select(c=>c.Pie.Price * c.Amount).Sum();
            return total;

        }

    }
}
