  
 using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Core.Entities;
using System;
using System.Text.Json;

namespace Infrastructuer.Data
 {
   public class StoreContextSeed
    {
        


        

        public static async Task SeedAsync(StoreContext context , ILoggerFactory loggerFactory)
        {
            try {

                if (!context.ProductTypes.Any())
                {
                    var typeData = File.ReadAllText("../Infrastructuer/Data/SeedData/types.json");

                    var TypeData = JsonSerializer.Deserialize<List<ProductType>>(typeData);


                    foreach (var item in TypeData)
                    {
                        context.ProductTypes.Add(item);

                    }

                    await context.SaveChangesAsync();




                }
                if (!context.ProductBrands.Any())
                {

                    var brandsData = File.ReadAllText("../Infrastructuer/Data/SeedData/brands.json");

                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);




                    foreach (var item in brands)
                    {
                        context.ProductBrands.Add(item);

                    }
                    await context.SaveChangesAsync();



                }


                var Productbrand = context.ProductBrands.ToList();
                
                var types = context.Products.ToList();
                if(!context.Products.Any())
                {

               

                    var product = File.ReadAllText("../Infrastructuer/Data/SeedData/products.json");

                    var ProductsData = JsonSerializer.Deserialize<List<Product>>(product);

                    foreach (var item in ProductsData)
                    {
                        context.Products.Add(item);
                   

                       }

                    await context.SaveChangesAsync();

                }










            }

            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);

            }


        }
    } 
}



