using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<PetOwner> GetPets() 
        {
            return _context.PetOwners;
        }

        //GET by id
        [HttpGet("{id}")]
        public ActionResult<PetOwner> GetById(int id)
        {
            PetOwner petOwner = _context.PetOwners.SingleOrDefault(petOwner => petOwner.id == id);

            if(petOwner is null)
            {
                return NotFound();
            }
            return petOwner;
        }

        //POST
        [HttpPost]
        public PetOwner Post(PetOwner petOwner)
        {
            _context.Add(petOwner);

            _context.SaveChanges();

            return petOwner;
        }

        //DELETE
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            PetOwner petOwner = _context.PetOwners.Find(id);

            _context.PetOwners.Remove(petOwner);

            _context.SaveChanges();;
        }
    }
}
