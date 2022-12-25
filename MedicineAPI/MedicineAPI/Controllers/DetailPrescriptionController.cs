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
    public class DetailPrescriptionController : ControllerBase
    {

        private readonly MyDbContext _context;
        public DetailPrescriptionController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var list = _context.detailPrescriptions.ToList();
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
                var list = _context.detailPrescriptions.SingleOrDefault(x => x.idDetailPrescription == Guid.Parse(id));
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
        public IActionResult AddNew(DetailPrescriptionModel model)
        {
            try
            {
                var list = new DetailPrescription
                {
                    idPrescription = model.idPrescription,
                    idMedicine = model.idMedicine,
                    quantityDetailPrescription = model.quantityDetailPrescription,
                    contentDetailPrescription = model.contentDetailPrescription,
                    hourDetailPrescription = model.hourDetailPrescription,
                    minuteDetailPrescription = model.minuteDetailPrescription,
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
        public IActionResult UpdateById(string id, DetailPrescriptionModel model)
        {
            try
            {
                var list = _context.detailPrescriptions.SingleOrDefault(x => x.idDetailPrescription == Guid.Parse(id));
                if (list != null)
                {
                    list.idPrescription = model.idPrescription;
                    list.idMedicine = model.idMedicine;
                    list.quantityDetailPrescription = model.quantityDetailPrescription;
                    list.contentDetailPrescription = model.contentDetailPrescription;
                    list.hourDetailPrescription = model.hourDetailPrescription;
                    list.minuteDetailPrescription = model.minuteDetailPrescription;
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
                var list = _context.detailPrescriptions.SingleOrDefault(x => x.idDetailPrescription == Guid.Parse(id));
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
