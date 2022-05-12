using Water_plant_BackEnd.Models;
using Water_plant_BackEnd.ViewModels;

namespace Water_plant_BackEnd.Services
{
    public interface IWaterPlantService
    {

        List<WaterPlantDetail> GetWaterPlantList();

        WaterPlantDetail GetWaterPlantById(int pId);

        ResponseModel<WaterPlantDetail> SaveWaterPlant(int id);

    }
}
