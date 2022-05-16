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
    public class StudentController : Controller
    {
        private readonly StudentSystemContext context;

        public StudentController(StudentSystemContext context)
        {
            this.context = context;
        }


        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Student.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetStudent")]
        public ActionResult Get(int id)
        {
            try
            {
                var student = context.Student.FirstOrDefault(S => S.IdStudent == id);
                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody] Student student)
        {
            try
            {
                context.Student.Add(student);
                context.SaveChanges();
                return CreatedAtRoute("GetStudent", new { id = student.IdStudent }, student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Student student)
        {
            try
            {
                if (student.IdStudent == id)
                {
                    context.Entry(student).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetStudent", new { id = student.IdStudent }, student);
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
                var student = context.Student.FirstOrDefault(s => s.IdStudent == id);
                if (student != null)
                {
                    context.Student.Remove(student);
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
