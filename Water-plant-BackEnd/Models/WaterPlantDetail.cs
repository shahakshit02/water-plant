using System.ComponentModel.DataAnnotations;

namespace Water_plant_BackEnd.Models
{
    public class WaterPlantDetail
    {
        [Key]
        public int pId { get; set; }
        [StringLength(50)]
        public string pName { get; set; }
        [StringLength(50)]
        public string waterStatus { get; set; }

        public DateTime waterTime { get; set; }
        public bool isWatering { get; set; }
        public int waterInterval { get; set; }
    }
}
