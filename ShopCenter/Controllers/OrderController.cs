using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopCenter.Models;

namespace ShopCenter.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {private readonly IOrderRepository _orderRepository;
        private readonly IShoppingCart _shoppingCart;
        public OrderController (IOrderRepository orderRepository,IShoppingCart ShoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = ShoppingCart;
        }
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems= items;
            if(_shoppingCart.ShoppingCartItems.Count==0)
            {
                ModelState.AddModelError("", "Your cart is empty ,add some Pies First");

            }
            if(ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");

            }
            return View(order);
        }
        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your Order.You ll soon enjoy our Pies";
            return View();
        }
    }
}
