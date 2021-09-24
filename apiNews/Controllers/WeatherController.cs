using apiNews.Context;
using apiNews.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiNews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly AppDbContext context;

        public WeatherController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<WeatherController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.weather.ToList());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET api/<WeatherController>/5
        [HttpGet("{city}", Name = "GetWeather")]
        public ActionResult Get(string city)
        {
            try
            {
                //var noticia = context.news.FirstOrDefault(n => n.id == id);
                var clima = context.weather.Where(n => n.city == city);
                return Ok(clima);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<WeatherController>
        [HttpPost]
        public ActionResult Post([FromBody] WeatherBd clima)
        {
            try
            {
                context.weather.Add(clima);
                context.SaveChanges();
                return CreatedAtRoute("GetWeather", new { id = clima.id }, clima);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<WeatherController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] WeatherBd clima)
        {
            try
            {
                if (clima.id == id)
                {
                    context.Entry(clima).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetWeather", new { id =  clima.id }, clima);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<WeatherController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var clima = context.weather.FirstOrDefault(n => n.id == id);
                if (clima != null)
                {
                    context.weather.Remove(clima);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
