using Expressions_PoC.Models;
using System;
using System.IO;
using System.Linq;

namespace Expressions_PoC
{
  public static class Boilerplate
  {
    static readonly Random RANDOM = new Random();
    static readonly string[] WORDS = File.ReadAllLines("words.txt");


    public static IQueryable<T> GenDataset<T>(int qty = 1000) where T: Cat
      => Enumerable.Range(0, qty).Select(s => Randomize<T>()).AsQueryable();


    static T Randomize<T>()
      where T : Cat
    { 
      switch(typeof(T))
      {
        case 
          var cls when cls == typeof(Cat): return (T)RandomizeCat();
        default: 
          return (T)RandomizeCat();
      };
    }

    static Cat RandomizeCat()
      => new Cat()
      {
        Legs = RANDOM.Next(4, 8),
        Name = WORDS[RANDOM.Next(0, WORDS.Length)],
        Colour = (FurColour)RANDOM.Next(0, Enum.GetNames(typeof(FurColour)).Length),
        MurdersTheCurtains = RANDOM.Next(0,1) == 1 ? true : false
      };

  }

}
