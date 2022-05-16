using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreAPI.Context;
using NetCoreAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    public class CourseController : Controller
    {
        private readonly StudentSystemContext context;

        public CourseController(StudentSystemContext context)
        {
            this.context = context;
        }


        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Course.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetCourse")]
        public ActionResult Get(int id)
        {
            try
            {
                var course = context.Course.FirstOrDefault(S => S.IdCourse == id);
                return Ok(course);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody] Course course)
        {
            try
            {
                context.Course.Add(course);
                context.SaveChanges();
                return CreatedAtRoute("GetCourse", new { id = course.IdCourse }, course);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Course course)
        {
            try
            {
                if (course.IdCourse == id)
                {
                    context.Entry(course).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetCourse", new { id = course.IdCourse }, course);
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

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var course = context.Course.FirstOrDefault(s => s.IdCourse == id);
                if (course != null)
                {
                    context.Course.Remove(course);
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
