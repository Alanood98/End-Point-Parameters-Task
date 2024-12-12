using EndPointParametersTask.ProductDTO;
using EndPointParametersTask.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("GetAllProducts")]
    public ActionResult<List<ProductOutputDTO>> GetAllProducts(int pageNumber = 1, int pageSize = 10)
    {
        return Ok(_productService.GetAllProducts( pageNumber,  pageSize));
    }

    [HttpGet("GetProductById/{id}")]
    public ActionResult<ProductOutputDTO> GetProductById(int id)
    {
        return Ok(_productService.GetProductById(id));
    }

    [HttpPost]
    public ActionResult<ProductOutputDTO> AddProduct( ProductInputDTO productInput)
    {
        return Ok(_productService.AddProduct(productInput));
    }

    [HttpPut("UpdateProduct/{id}")]
    public ActionResult<ProductOutputDTO> UpdateProduct(int id,  ProductInputDTO productInput)
    {
        return Ok(_productService.UpdateProduct(id, productInput));
    }

    [HttpDelete("DeleteProduct/{id}")]
    public ActionResult<string> DeleteProduct(int id)
    {
        return Ok(_productService.DeleteProduct(id));
    }
}
