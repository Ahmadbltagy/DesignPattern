using System.Diagnostics;
using SolidPrinciple.SingleResponsibility;

var j = new Journal();

j.AddEntry("First entry");
j.AddEntry("Second entry");

System.Console.WriteLine(j);

string filePath = @"/home/ahmadbltagy/Desktop/cSharpfile.txt";
Persistence.SaveToFile(j, filePath);
// Process.Start(filePath);







