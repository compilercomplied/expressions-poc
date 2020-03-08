using Expressions_PoC.Filters;
using Expressions_PoC.Models;
using System;
using System.Linq;

namespace Expressions_PoC
{
  class Program
  {
    static void Main(string[] args)
    {

      ExecuteSimple();

      Console.ReadKey();

    }

    static void ExecuteSimple()
    {

      const int qty = 1000;

      var dataset = Boilerplate.GenDataset<Cat>(qty);

      var cat = new Cat() { Legs = 4, MurdersTheCurtains = false, Colour = FurColour.rainbow };

      var filter = Filter.ByMatch(cat);

      var matches = dataset.Where(filter).AsEnumerable();

      Console.WriteLine($"With a randomly generated dataset of {qty} cats...");
      Console.WriteLine($"There were {matches.Count()} matches.");
      Console.WriteLine($"With the first one being:");
      Console.WriteLine($"{matches.FirstOrDefault()?.ToString() ?? "null"}");

    }

  }
}
