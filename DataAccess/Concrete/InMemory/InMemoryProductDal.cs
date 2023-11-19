using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;  //SingerOrDefault gelmez bu eklenmezse.
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        //ctor tab
        public InMemoryProductDal()  //sadece methodun adı varsa Constructor
        {

            //Oracle, Sql Server, MongoDB, Postgre
            _products = new List<Product> { 
            new Product{ ProductId=1, CategoryId=1, ProductName="Bardak", UnitPrice=15, UnitsInStock=15},
            new Product{ ProductId=2, CategoryId=1, ProductName="Kamera", UnitPrice=500, UnitsInStock=3},
            new Product{ ProductId=3, CategoryId=2, ProductName="Telefon", UnitPrice=1500, UnitsInStock=2},
            new Product{ ProductId=4, CategoryId=2, ProductName="Klavye", UnitPrice=150, UnitsInStock=65},
            new Product{ ProductId=5, CategoryId=2, ProductName="Fare", UnitPrice=85, UnitsInStock=1},

            };   
            
        }
        public void Add(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            //Product productToDelete=null;
            //foreach (var p in _products)
            //{
            //    if(product.ProductId==p.ProductId)
            //    { //Silinecek eleman
            //        productToDelete = p;
            //    }
            //}
            //LAMBDA =>                                 //p yi dolaş    //Kuralı
            Product productToDelete =_products.SingleOrDefault(p=> product.ProductId == p.ProductId); // productsı tek tek dolaşmaya yarar
                                        //First - FirstOrDefault da olur.
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        //public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        //{
        //    throw new NotImplementedException();
        //}

        public List<Product> GetAllByCategory(int categoryId)
        {                   //İçindeki koşulu sağlayan tüm elemanları yeni bir liste yapar.
            return _products.Where(p=>p.CategoryId==categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id sine sahip olan ürün idsini bul
            Product productToUpdate = _products.SingleOrDefault(p => product.ProductId == p.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        
        }
    }
}
