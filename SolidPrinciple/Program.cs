#region SingleResposibility
/*
using System.Diagnostics;
using SolidPrinciple.SingleResponsibility;

var j = new Journal();

j.AddEntry("First entry");
j.AddEntry("Second entry");

System.Console.WriteLine(j);

string filePath = @"/home/ahmadbltagy/Desktop/cSharpfile.txt";
Persistence.SaveToFile(j, filePath);
Process.Start(filePath);
*/
#endregion

#region  OpenClosed

using SolidPrinciple.OpenClosed;

var products = new List<Product>()
{
    new Product("Apple", Color.Red, Size.Small),
    
    new Product("Tree", Color.Green, Size.Medium),
    
    new Product("Palm", Color.Green, Size.Large),
    new Product("House", Color.Blue, Size.Large),
};

// var filteredProduct = new ProductFilter().FilterBySize(products,Size.Large);

// foreach(var product in filteredProduct)
// {
//     System.Console.WriteLine(product._name);
// }


var bf = new BetterProductFilter();
var colorSpec = new ColorSpecification(Color.Green);
var sizeSpec = new SizeSpecification(Size.Large);

var filterByColor = bf.Filter(products, colorSpec);
var filterBySize = bf.Filter(products, sizeSpec);
var filterBySizeAndColor = bf.Filter(products, new SizeAndColorSpecification(Size.Small, Color.Red));
//betterImplementForFilterByColorAndSize
var filterByColorAndSize = bf.Filter(products, new AndSpecification<Product>(colorSpec,sizeSpec));

System.Console.WriteLine("Filter By Color.");
foreach (var product in filterByColor)
{
    System.Console.WriteLine($" -{product._name}");
}

System.Console.WriteLine("Filter By Size.");
foreach (var product in filterBySize)
{
    System.Console.WriteLine($" -{product._name}");
}

System.Console.WriteLine("Filter By Color And Size.");
foreach (var product in filterByColorAndSize)
{
    System.Console.WriteLine($" -{product._name}");
}

#endregion



