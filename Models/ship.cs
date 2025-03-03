using System.ComponentModel.DataAnnotations;

namespace ShipCreator1.Models;

public class ship
{
    
    public int ShipID { get; set; }
    [Required]
    public string ShipName { get; set; }
    [Required]
    public string ShipType { get; set; }
    [Range(0, int.MaxValue)]
    public int NauticalMilage { get; set; }
    public string PledgedFaction { get; set; }
    
}