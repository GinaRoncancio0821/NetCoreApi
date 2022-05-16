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
    public class NoteController : Controller
    {
        private readonly StudentSystemContext context;

        public NoteController(StudentSystemContext context)
        {
            this.context = context;
        }


        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Note.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetNote")]
        public ActionResult Get(int id)
        {
            try
            {
                var note = context.Note.FirstOrDefault(S => S.IdNote == id);
                return Ok(note);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody] Note note)
        {
            try
            {
                context.Note.Add(note);
                context.SaveChanges();
                return CreatedAtRoute("GetNote", new { id = note.IdNote }, note);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Note note)
        {
            try
            {
                if (note.IdNote == id)
                {
                    context.Entry(note).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetNote", new { id = note.IdNote }, note);
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
                var note = context.Note.FirstOrDefault(s => s.IdNote == id);
                if (note != null)
                {
                    context.Note.Remove(note);
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
