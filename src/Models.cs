
namespace Expressions_PoC.Models
{

  public class Cat
  {

    public int? Legs { get; set; }
    public string Name { get; set; }
    public FurColour? Colour { get; set; }
    public bool? MurdersTheCurtains { get; set; }

    public override string ToString()
      => $"{Name}, a {Colour?.ToString() ?? string.Empty} coloured, {Legs}-legged cat that does {(MurdersTheCurtains.HasValue && MurdersTheCurtains.Value ? string.Empty : "not")} murder the curtains";
    

  }

  public enum FurColour
  { 
    snow   = 0,
    ash   = 1,
    rainbow = 2,
  }

}
