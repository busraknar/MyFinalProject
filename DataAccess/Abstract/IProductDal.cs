using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    { //Ientity yi product için yapılandırdın.
        
        
        
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
