using Microsoft.AspNetCore.Mvc;
using Nograd.Clients.CustomerApp.Models.Cart;
using Nograd.Clients.CustomerApp.Models.Order;
using Nograd.OrderService.Commands.Client;

namespace Nograd.Clients.CustomerApp.Controllers;

public sealed class OrderController : Controller
{
    private readonly IOrderCommandsClient _client;
    private readonly Cart _cart;
    private readonly IOrderMapper _orderMapper;

    public OrderController(
        IOrderCommandsClient client,
        Cart cart,
        IOrderMapper orderMapper)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
        _cart = cart ?? throw new ArgumentNullException(nameof(cart));
        _orderMapper = orderMapper ?? throw new ArgumentNullException(nameof(orderMapper));
    }


    [HttpPost]
    public async Task<IActionResult> Checkout(OrderViewModel order)
    {
        if (!_cart.Lines.Any()) ModelState.AddModelError("", "Sorry, your cart is empty!");


        if (ModelState.IsValid)
        {
            order.Lines = _cart.Lines.ToArray();

            var input = _orderMapper.Map(order);
            var output = await _client.CreateOrderAsync(input);

            _cart.Clear();
            return RedirectToPage("/Completed", new { orderId = output.OrderId });
        }

        return View();
    }


    public ViewResult Checkout()
    {
        return View(new OrderViewModel());
    }
}