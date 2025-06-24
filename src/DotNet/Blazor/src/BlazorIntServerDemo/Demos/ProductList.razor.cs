using Microsoft.AspNetCore.Components;

namespace BlazorIntServerDemo.Demos;

[Route("/ProductListDemo")]
public partial class ProductList
{
    private string _pageTitle = "ProductList";
    private List<Product> _products = new();

    protected override void OnInitialized()
    {
        _products.Add(new Product { Id = "1", Name = "Product 1", Price = 100 });
        _products.Add(new Product { Id = "2", Name = "Product 2", Price = 200 });
        _products.Add(new Product { Id = "3", Name = "Product 3", Price = 300 });
        base.OnInitialized();
    }

    class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
