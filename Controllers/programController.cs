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
    public class ProgramController : Controller
    {
        private readonly StudentSystemContext context;

        public ProgramController(StudentSystemContext context)
        {
            this.context = context;
        }


        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Program.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetProgram")]
        public ActionResult Get(int id)
        {
            try
            {
                var program = context.Program.FirstOrDefault(S => S.IdProgram == id);
                return Ok(program);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody] Programs program)
        {
            try
            {
                context.Program.Add(program);
                context.SaveChanges();
                return CreatedAtRoute("GetProgram", new { id = program.IdProgram }, program);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Programs program)
        {
            try
            {
                if (program.IdProgram == id)
                {
                    context.Entry(program).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetProgram", new { id = program.IdProgram }, program);
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
                var program = context.Program.FirstOrDefault(s => s.IdProgram == id);
                if (program != null)
                {
                    context.Program.Remove(program);
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
