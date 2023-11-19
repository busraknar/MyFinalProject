using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

internal class Program
{
    private static void Main(string[] args)
    {
        ProductTest();
        //CategoryTest();

    }

    private static void CategoryTest()
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        foreach (var category in categoryManager.GetAll())
        {
            Console.WriteLine(category.CategoryName);
        }
    }

    private static void ProductTest()
    {
        //foreach (var product in productManager.GetAll())
        //{
        //    Console.WriteLine(product.ProductName);
        //}

        ProductManager productManager = new ProductManager(new EfProductDal());
        //foreach (var product in productManager.GetAllByCategoryId(2))
        //{
        //    Console.WriteLine(product.ProductName);
        //}

        //foreach (var product in productManager.GetProductDetails().Data)
        //{
        //    Console.WriteLine(product.ProductName+"/" + product.CategoryName);
        //}
        var result = productManager.GetProductDetails();
        if (result.Success==true)
        {
            foreach (var product in result.Data)
            {
                Console.WriteLine(product.ProductName + "/" + product.CategoryName);
            }
        }
        else
        {
            Console.WriteLine(result.Message);
        }
    }
}