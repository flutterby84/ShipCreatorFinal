using System.ComponentModel.DataAnnotations;

namespace ShipCreator1.Models;

public class Ship
{
    
    public int ShipID { get; set; }
    [Required]
    [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
    public string ShipName { get; set; }
    [Required]
    [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
    public string ShipType { get; set; }
    [Range(0, int.MaxValue)]
    public int NauticalMilage { get; set; }
    public string PledgedFaction { get; set; }
    
}