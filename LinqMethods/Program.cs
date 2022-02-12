using System;

namespace Linqmethos
{
    class Program
    {
        static void Main(String[] args)
        {
            Console.WriteLine();
            Console.WriteLine("union");
            var numbers1 = new int[] { 1, 2, 3, 4, 5 };
            var numbers2 = new int[] { 6, 7, 8, 9, 10,12,3,23 };

            //metodo union
            var numberUnion = numbers1.Union(numbers2); 

            numberUnion.ToList().ForEach(x => Console.WriteLine(x));

            Console.WriteLine();
            Console.WriteLine("ZIP");
            //metodo zip, mezcla de dos colecciones
            var ArrayZipNumber = new int[] { 1, 2, 3, 4, 5 };
            var ArrayZipstring = new string[] { "uno", "dos", "tres", "cuatro", "cinco" };

            var numberWithZip = ArrayZipNumber.Zip(ArrayZipstring, (n, w) =>
            {
                return n + " " + w;
            });
            numberWithZip.ToList().ForEach(x => Console.WriteLine(x));

            Console.WriteLine();
            Console.WriteLine("Join");

            var beer = new List<(string Name, int IdBrand)>
            {
                ("Pikantus",1),
                ("Dunkel",1),
                ("Corona",2),
                ("Tecate",2)
            };

            var brand = new List<(int IdBrand, string Name)>
            {
                (1,"Erdinger"),
                (2,"Grupo Modelo")
            };

            var beerDetail = beer.Join(brand, b => b.IdBrand, br => br.IdBrand, (beer, brand) =>
             {
                 return new
                 {
                     Name = beer.Name,
                     BrandName = brand.Name,
                 };
             });

            beerDetail.ToList().ForEach(element =>
            {
                Console.WriteLine($"{element.Name} {element.BrandName}");
            });
            Console.WriteLine();
            Console.WriteLine("Metodo All");

            var ArrayAll1 = new int[] { 1, 2, 3, 4, 5 };
            var ArrayAll2 = new int[] { 6, 7, 8, 9, 10 };

            Console.WriteLine(ArrayAll1.All(e => e > 5));
            Console.WriteLine(ArrayAll2.All(e => e > 5));

            Console.WriteLine();
            Console.WriteLine("Select Mani");

            Console.WriteLine();
            Console.WriteLine("Select Many");

            var beersBrand = new List<(string Name, List<string> Beers)>
            {
                ("Erdinger", new List<string>{ "Pikantus","Dunke"}),
                ("Delirium", new List<string>{ "Tremes","Red"})
            };

            var beerDetails =
                beersBrand.SelectMany(beersBrand => beersBrand.Beers,
                    (beerBrand, beer) => new { beerBrand, beer }
                    ).Select(beerBrand =>
                    {
                        return new
                        {
                            BrandName = beerBrand.beerBrand.Name,
                            BeerName = beerBrand.beer
                        };
                    });

            beerDetails.ToList().ForEach(beer =>
            {
                Console.WriteLine($"{beer.BrandName} {beer.BeerName}");
            });
        }
    }
}