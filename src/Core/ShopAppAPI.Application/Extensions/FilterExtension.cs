using System.Linq.Expressions;
using ShopAppAPI.Application.Dtos.Product;
using ShopAppAPI.Domain.Entities;

namespace ShopAppAPI.Application.Extensions;

public static class FilterExtension
{
    public static List<Expression<Func<Product, bool>>> CreateProductFilter(ProductFilterDto productFilter)
    {
        var filters = new List<Expression<Func<Product, bool>>>();

        if (productFilter.Name != null)
            filters.Add(f => f.Name.Equals(productFilter.Name));
        if (productFilter.Price != null)
            filters.Add(f => f.Price == productFilter.Price);
        if (productFilter.CategoryId != null)
            filters.Add(f => f.CategoryId == productFilter.CategoryId);

        filters.Add(f => f.Stock > 0);

        return filters;
    }
}
