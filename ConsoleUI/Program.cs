﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

internal class Program
{
    private static void Main(string[] args)
    {
        ProductManager productManager = new ProductManager(new EfProductDal());

        //foreach (var product in productManager.GetAll())
        //{
        //    Console.WriteLine(product.ProductName);
        //}

        foreach (var product in productManager.GetAllByCategoryId(2))
        {
            Console.WriteLine(product.ProductName);
        }

    }
}