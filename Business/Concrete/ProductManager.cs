using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        //Generate Constructor
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        { //IproductDal referansı ver. InMemory de olabilir, framework de interfacede
            _productDal = productDal;
        }
        
        public IResult Add(Product product)
        {
        //    _productDal.Add(product); 
        //    return new Result(true,"Ürün eklendi.");
            if(product.ProductName.Length<2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);//"Ürün eklendi.")
        }

        public IDataResult<List<Product>> GetAll()
        {
            //Yetkisi var mı? kodları
            //İş kodları  //Bir iş sınıfı başka sınıfları new lemez.
          if(DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime); //MaintenanceTime için generate field
            }
            
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed); //Generate field dedik ProductListed
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=> p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductId== productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.UnitPrice<=min && p.UnitPrice<=max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
    }
}
