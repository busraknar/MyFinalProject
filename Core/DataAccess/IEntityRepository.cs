

using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess   //CORE KATMANLARI DİĞER SINIFLARI REFERANS ALMAZ
{
    //generic constraint-- jenerik kısıt
    // class = referans tip - sınıf demek değil
    //IEntity - IEntity olabilir ya da implement eden nesne olabilir
    //new() - new'lenebilir olmalı

    public interface IEntityRepository<T> where T : class, IEntity ,new()
        //AMPUL GELMİYORSA CTRL NOKTA
    {
        List<T> GetAll(Expression<Func <T,bool>> filter=null);
        //p=> p.categoryIdgibi filtreler oluşturabilmek için Expression kullanılır.
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
      
    }
}
