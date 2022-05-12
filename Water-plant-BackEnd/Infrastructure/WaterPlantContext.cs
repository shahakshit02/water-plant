using Microsoft.EntityFrameworkCore;
using Water_plant_BackEnd.Models;

namespace Water_plant_BackEnd.Infrastructure
{
    public class WaterPlantContext: DbContext
    {
        public WaterPlantContext(DbContextOptions options) : base(options) { }
        DbSet<WaterPlantDetail> WaterPlantDetails
        {
            get;
            set;
        }
        
    }
}
