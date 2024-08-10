using System.Collections.Generic;
using PurchaseApp.Domain;

namespace PurchaseApp.Data
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        //revisa los sgts metodos
    }
}
/* By implementing the repository pattern, you have created a clean separation between your data access 
 * logic and your business logic. The IProductRepository interface defines the contract for accessing 
 * product data, while the ProductRepository class provides the implementation using Entity Framework Core.
This approach enhances maintainability and testability in your application, allowing you to easily mock 
the repository in unit tests or swap out the data access layer in the future if needed. */