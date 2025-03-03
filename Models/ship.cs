using System.ComponentModel.DataAnnotations;

namespace ShipCreator1.Models;

public class ship
{
    [Required]
    public int ShipID { get; set; }
    
    public string ShipName { get; set; }
    public string ShipType { get; set; }
    public int NauticalMilage { get; set; }
    
}