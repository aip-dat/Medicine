using MedicineAPI.Data;
using MedicineAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Type = MedicineAPI.Data.Type;

namespace MedicineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly MyDbContext _context;
        public TypesController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var list = _context.types.ToList();
                return Ok(list);
            }
            catch
            {
                return BadRequest();
            }
            
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var list = _context.types.SingleOrDefault(x => x.idType == id);
            if (list != null)
            {
                return Ok(list);

            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult AddNew(TypeModel model)
        {
            try
            {
                var list = new Type
                {
                    nameType = model.nameType
                };
                _context.Add(list);
                _context.SaveChanges();
                return Ok(list);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, TypeModel model)
        {
            var list = _context.types.SingleOrDefault(x => x.idType == id);
            if (list != null)
            {
                list.nameType = model.nameType;
                _context.SaveChanges();
                return NoContent();

            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var list = _context.types.SingleOrDefault(x => x.idType == id);
            if (list != null)
            {
                _context.Remove(list);
                _context.SaveChanges();
                return Ok();

            }
            else
            {
                return NotFound();
            }
        }


    }
}
