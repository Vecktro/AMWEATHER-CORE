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
    public class UserController : ControllerBase
    {

        [HttpGet]
        public JsonResult Get()
        {
            using (WeatherAppDbContext db = new WeatherAppDbContext())
            {
                var users = db.User.ToList();
                return new JsonResult(users);
            }
        }

        [HttpPost("Login")]
        public JsonResult Login(UserAuthViewModel user)
        {
            using (WeatherAppDbContext db = new WeatherAppDbContext())
            {
                var model = db.User.Find(user.Email);
                var result = new object();
                
                if (model != null)
                {
                    if (model.Password == user.Password)
                    {
                        result = new JsonResult(model);
                    }
                    else
                    {
                        result = new JsonResult("Usuario o contraseña invalidos.");
                    }
                }
                else
                {
                    result = new JsonResult("Invalid");
                }
                return new JsonResult(result);
            }
        }

        [HttpPost]
        public JsonResult Post( User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (WeatherAppDbContext db = new WeatherAppDbContext())
                    {
                        var model = new User()
                        {
                            Nombre = user.Nombre,
                            Apellido = user.Apellido,
                            Email = user.Email,
                            Password = user.Password
                        };
                        db.User.Add(model);
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

        [HttpPut]
        public JsonResult Put( User user)
        {
            using (WeatherAppDbContext db = new WeatherAppDbContext())
            {

                db.Entry(user).State = EntityState.Modified();
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
