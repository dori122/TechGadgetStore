using TechGadgetStore.Models;

namespace TechGadgetStore.Services;

public class CartService
{
    private List<CartItem> cartItems = new();

    public event Action? OnCartChanged;

    public List<CartItem> GetCartItems() => cartItems;

    public int GetCartCount() => cartItems.Sum(item => item.Quantity);

    public decimal GetCartTotal()
    {
        return cartItems.Sum(item => 
        {
            var price = item.Product.DiscountPrice ?? item.Product.Price;
            return price * item.Quantity;
        });
    }

    public void AddToCart(Product product)
    {
        var existingItem = cartItems.FirstOrDefault(item => item.Product.Id == product.Id);
        
        if (existingItem != null)
        {
            existingItem.Quantity++;
        }
        else
        {
            cartItems.Add(new CartItem 
            { 
                Product = product, 
                Quantity = 1 
            });
        }
        
        OnCartChanged?.Invoke();
    }

    public void RemoveFromCart(int productId)
    {
        var item = cartItems.FirstOrDefault(item => item.Product.Id == productId);
        if (item != null)
        {
            cartItems.Remove(item);
            OnCartChanged?.Invoke();
        }
    }

    public void UpdateQuantity(int productId, int quantity)
    {
        var item = cartItems.FirstOrDefault(item => item.Product.Id == productId);
        if (item != null)
        {
            if (quantity <= 0)
            {
                RemoveFromCart(productId);
            }
            else
            {
                item.Quantity = quantity;
                OnCartChanged?.Invoke();
            }
        }
    }

    public void ClearCart()
    {
        cartItems.Clear();
        OnCartChanged?.Invoke();
    }
}

public class CartItem
{
    public Product Product { get; set; } = null!;
    public int Quantity { get; set; }
}