using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]  //ATTRIBUTE
    public class ProductsController : ControllerBase
    {

        //IoC =>Inversion of Control

        IProductService _productService;  //Generate Constractor
        //loosly coupled : gevşek bağımlılık => Servis değiştirirsek managerda değişirse bir sorun yaşamayız.

        public ProductsController(IProductService productService)  //Controller sen IProductServis bağımlısısın.
        {                                   //Bana manager ver demek.
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()   /// api/products diyerek gidilir. ProductsController olduğu için
        {                            //add reference
            //IProductService productService = new ProductManager(new EfProductDal());  altı çizgili olmayanla çalışır.
            var result= _productService.GetAll();  //F10 la sonraki aşamaya geçeriz

            if (result.Success) 
            {
                return Ok(result);
            }
            return BadRequest(result);

            //return new List<Product>
            //{
            //    //new Product{ProductId=1,ProductName="Elma"},
            //    //new Product{ProductId=2,ProductName="Armut"}
            //};
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id) 
        {
            var result = _productService.GetById(id);
            if(result.Success) 
            {
                return Ok(result);
            }
            return BadRequest(result);

        }



        [HttpPost("add")]  //Bir şey göndermemiz lazım.  BODY_RAW_JSON
        public IActionResult Add(Product product) 
        {
            var result = _productService.Add(product);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }





    }
}


// public string Get()   /// api/products diyerek gidilir. ProductsController oduğu için
//{                            //add reference
//    IProductService productService = new ProductManager(new EfProductDal());
//    var result = productService.GetAll();  //F10 la sonraki aşamaya geçeriz
//    return result.Message;