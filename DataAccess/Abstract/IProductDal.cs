using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //Coding Refactoring - Kodun İyileştirilmesi
    public interface IProductDal:IEntityRepository<Product>
    { //Ientity yi product için yapılandırdın.
        List<ProductDetailDto> GetProductDetails();
        
        //Add reference entities
        //Data Access- Add-Project Reference - Entity seç
        //List<Product> GetAll();

        //void Add(Product product);
        //void Update(Product product);
        //void Delete(Product product);
        //Ürünleri kategoriye göre filtrele
        //List<Product> GetAllByCategory(int categoryId);


    }
}
