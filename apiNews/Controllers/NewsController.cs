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
    public class NewsController : ControllerBase
    {
        private readonly AppDbContext context;

        public NewsController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<NewsController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.news.ToList());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET api/<NewsController>/5
        [HttpGet("{id}", Name ="GetNoticia")]
        public ActionResult Get(int id)
        {
            try
            {
                var noticia = context.news.FirstOrDefault(n => n.id == id);
                return Ok(noticia);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<NewsController>/5
        [HttpGet("{city}", Name = "GetNoticias")]
        public ActionResult GetNoticias(string city)
        {
            try
            {
                var noticia = context.news.Where(n => n.city == city).ToList();
                return Ok(noticia);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<NewsController>
        [HttpPost]
        public ActionResult Post([FromBody] NewsBd noticia)
        {
            try
            {
                context.news.Add(noticia);
                context.SaveChanges();
                return CreatedAtRoute("GetNoticia", new { id = noticia.id }, noticia);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<NewsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] NewsBd noticia)
        {
            try
            {
                if (noticia.id == id)
                {
                    context.Entry(noticia).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetNoticia", new { id = noticia.id }, noticia);
                }
                else {
                    return BadRequest();
                }             

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<NewsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var noticia = context.news.FirstOrDefault(n => n.id == id);
                if (noticia!= null)
                {
                    context.news.Remove(noticia);
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
