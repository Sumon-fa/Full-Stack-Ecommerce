using backend.Models;
using backend.DTOs;
using backend.Services;

namespace backend.Controllers;

public class ProductController : CrudController<Product, ProductDTO>
{
    public ProductController(ICrudService<Product, ProductDTO> service) : base(service)
    {

    }
}
