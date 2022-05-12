using Microsoft.EntityFrameworkCore;
using Water_plant_BackEnd.Infrastructure;
using Water_plant_BackEnd.Models;
using Water_plant_BackEnd.ViewModels;

namespace Water_plant_BackEnd.Services
{
    public class WaterPlantService : IWaterPlantService
    {
        private DbContext _context;
        public WaterPlantService(WaterPlantContext context)
        {
            _context = context;
        }

        public WaterPlantDetail GetWaterPlantById(int pId)
        {
            WaterPlantDetail water;
            try
            {
                water = _context.Find<WaterPlantDetail>(pId);
            }
            catch (Exception)
            {
                throw;
            }
            return water;
        }

        public List<WaterPlantDetail> GetWaterPlantList()
        {
            List<WaterPlantDetail> waterPlantList;
            try
            {
                waterPlantList = _context.Set<WaterPlantDetail>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return waterPlantList;
        }

        public ResponseModel<WaterPlantDetail> SaveWaterPlant(int id)
        {
            ResponseModel<WaterPlantDetail> model = new ResponseModel<WaterPlantDetail>();
            try
            {
                WaterPlantDetail _temp = GetWaterPlantById(id);
                if (_temp.pId != null)
                {
                    var currentDate = DateTime.Now;
                    var seconds = (currentDate - _temp.waterTime).TotalSeconds;

                    if (seconds >= 10 && _temp.isWatering == true)
                    {
                        model.IsSuccess = true;
                        model.TestingMesssage = "You have watered the plant";
                        _temp.isWatering = false;
                        _temp.waterTime = currentDate;
                        _temp.waterStatus = "watered";
                    }
                    else{
                        if(seconds >= 30)
                        {
                            model.IsSuccess = true;
                            _temp.isWatering = true;
                             _temp.waterTime = currentDate;
                            _temp.waterStatus = "watering";
                        } else
                        {
                            model.IsSuccess = false;
                            model.TestingMesssage = "Wait for 30 seconds before watering the plant";
                        }
                        
                    }

                    _context.Update<WaterPlantDetail>(_temp);
                    _context.SaveChanges();
                    model.Data = _temp;
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.TestingMesssage = "Error : " + ex.Message;
            }
            return model;
        }
    }
}
