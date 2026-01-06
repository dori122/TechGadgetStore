using TechGadgetStore.Models;
using TechGadgetStore.Services;

namespace TechGadgetStore.Interfaces;

public interface ICartService
{
    event Action? OnCartChanged;
    List<CartItem> GetCartItems();
    int GetCartCount();
    decimal GetCartTotal();
    void AddToCart(Product product);
    void RemoveFromCart(int productId);
    void UpdateQuantity(int productId, int quantity);
    void ClearCart();
}
