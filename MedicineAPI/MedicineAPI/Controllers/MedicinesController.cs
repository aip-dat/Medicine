using MedicineAPI.Data;
using MedicineAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinesController : ControllerBase
    {
        private readonly MyDbContext _context;
        public MedicinesController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var list = _context.medicines.ToList();
                return Ok(list);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var list = _context.medicines.SingleOrDefault(x => x.idMedicine == Guid.Parse(id));
                if (list != null)
                {
                    return Ok(list);

                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult AddNew(MedicineModel model)
        {
            try
            {
                var list = new Medicine
                {
                    nameMedicine = model.nameMedicine,
                    descriptionMedicine = model.descriptionMedicine,
                    numberMedicine = model.numberMedicine,
                    idType = model.idType,
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
        public IActionResult UpdateById(string id, MedicineModel model)
        {
            try
            {
                var list = _context.medicines.SingleOrDefault(x => x.idMedicine == Guid.Parse(id));
                if(list != null)
                {
                    list.nameMedicine = model.nameMedicine;
                    list.descriptionMedicine = model.descriptionMedicine;
                    list.numberMedicine = model.numberMedicine;
                    list.idType = model.idType;
                    _context.SaveChanges();
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(string id)
        {
            try
            {
                var list = _context.medicines.SingleOrDefault(x => x.idMedicine == Guid.Parse(id));
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
            catch
            {
                return BadRequest();
            }
        }
    }
}
