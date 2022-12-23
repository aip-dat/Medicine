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
    public class PrescriptionsController : ControllerBase
    {
        private readonly MyDbContext _context;
        public PrescriptionsController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var list = _context.prescriptions.ToList();
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
                var list = _context.prescriptions.SingleOrDefault(x => x.idPrescription == Guid.Parse(id));
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
        public IActionResult AddNew(PrescriptionModel model)
        {
            try
            {
                var list = new Prescription
                {
                    idDrUser = model.idDrUser,
                    idMedicine = model.idMedicine,
                    quantityPrescription = model.quantityPrescription,
                    contentPrescription = model.contentPrescription,
                    hourPrescription = model.hourPrescription,
                    minutePrescription = model.minutePrescription,
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
        public IActionResult UpdateById(string id, PrescriptionModel model)
        {
            try
            {
                var list = _context.prescriptions.SingleOrDefault(x => x.idPrescription == Guid.Parse(id));
                if (list != null)
                {
                    list.idDrUser = model.idDrUser;
                    list.idMedicine = model.idMedicine;
                    list.quantityPrescription = model.quantityPrescription;
                    list.contentPrescription = model.contentPrescription;
                    list.hourPrescription = model.hourPrescription;
                    list.minutePrescription = model.minutePrescription;
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
                var list = _context.prescriptions.SingleOrDefault(x => x.idPrescription == Guid.Parse(id));
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
