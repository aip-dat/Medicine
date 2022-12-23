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
    public class UsersController : ControllerBase
    {
        private readonly MyDbContext _context;
        public UsersController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var list = _context.users.ToList();
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
                var list = _context.users.SingleOrDefault(x => x.idUser == Guid.Parse(id));
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
        public IActionResult AddNew(UserModel model)
        {
            try
            {
                var list = new User
                {
                    nameUser = model.nameUser,
                    passwordUser = model.passwordUser,
                    fullNameUser = model.fullNameUser,
                    emailUser = model.emailUser,
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
        public IActionResult UpdateById(string id, UserModel model)
        {
            try
            {
                var list = _context.users.SingleOrDefault(x => x.idUser == Guid.Parse(id));
                if (list != null)
                {
                    list.nameUser = model.nameUser;
                    list.passwordUser = model.passwordUser;
                    list.fullNameUser = model.fullNameUser;
                    list.emailUser = model.emailUser;
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
                var list = _context.users.SingleOrDefault(x => x.idUser == Guid.Parse(id));
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
