using Models.Request;
using Models.Response;

namespace BusinessLogic
{
    public interface IProductService
    {
        EligibleProductsResponse GetProducts(EligibleProductsRequest request);
    }
}