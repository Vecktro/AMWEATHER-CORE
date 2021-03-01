using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMWEATHER_CORE.Constant;
using AMWEATHER_CORE.Context;
using AMWEATHER_CORE.Model;
using AMWEATHER_CORE.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AMWEATHER_CORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherAuditoryController : ControllerBase
    {

        [HttpGet]
        public JsonResult Get()
        {
            using (WeatherAppDbContext db = new WeatherAppDbContext())
            {
                var auditory = db.WeatherAuditory.ToList();
                return new JsonResult(auditory);
            }
        }

        [HttpPost]
        public JsonResult Post(WeatherAuditoryViewModel auditory)
        {
            if(!String.IsNullOrEmpty(auditory.Email))
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        using (WeatherAppDbContext db = new WeatherAppDbContext())
                        {
                            var model = new WeatherAuditory()
                            {
                                Email = auditory.Email,
                                CityCode = auditory.CityCode,
                                CountryCode = auditory.CountryCode,
                                Day = DateTime.Now.ToString(),
                                Temperature = auditory.Temperature
                            };
                            db.WeatherAuditory.Add(model);
                            db.SaveChanges();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return new JsonResult("Added Succefuly");
            }

            return new JsonResult("continue");
        }

        [HttpPut]
        public JsonResult Put(WeatherAuditory auditory)
        {
            using (WeatherAppDbContext db = new WeatherAppDbContext())
            {
                db.Entry(auditory).State = EntityState.Modified();
                db.SaveChanges();
            }
            return new JsonResult("Updated Succefuly");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(string id)
        {
            using (WeatherAppDbContext db = new WeatherAppDbContext())
            {
                var user = db.User.Find(id);
                db.Entry(user).State = EntityState.Delete();
                db.SaveChanges();
            }
            return new JsonResult("The user was deleted.");
        }
    }
}
