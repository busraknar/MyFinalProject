using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
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

        public List<Product> GetAll()
        {
            //Yetkisi var mı? kodları
            //İş kodları  //Bir iş sınıfı başka sınıfları new lemez.
           return _productDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p=> p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p=>p.UnitPrice<=min && p.UnitPrice<=max);
        }
    }
}
