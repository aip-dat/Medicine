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
    public class DrUsersController : ControllerBase
    {
        private readonly MyDbContext _context;
        public DrUsersController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var list = _context.drUsers.ToList();
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
                var list = _context.drUsers.SingleOrDefault(x => x.idDrUser == Guid.Parse(id));
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
        public IActionResult AddNew(DrUserModel model)
        {
            try
            {
                var list = new DrUser
                {
                    nameDrUser = model.nameDrUser,
                    passwordDrUser = model.passwordDrUser,
                    fullNameDrUser = model.fullNameDrUser,
                    emailDrUser = model.emailDrUser,
                    phoneDrUser = model.phoneDrUser,
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
        public IActionResult UpdateById(string id, DrUserModel model)
        {
            try
            {
                var list = _context.drUsers.SingleOrDefault(x => x.idDrUser == Guid.Parse(id));
                if (list != null)
                {
                    list.nameDrUser = model.nameDrUser;
                    list.passwordDrUser = model.passwordDrUser;
                    list.fullNameDrUser = model.fullNameDrUser;
                    list.emailDrUser = model.emailDrUser;
                    list.phoneDrUser = model.phoneDrUser;
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
                var list = _context.drUsers.SingleOrDefault(x => x.idDrUser == Guid.Parse(id));
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
