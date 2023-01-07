using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Core.WineCollection.Models;
using BookStore.Core.WineCollection.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class MongoWineController : ControllerBase
    {
        private readonly IWineServices _wineServices;

        public MongoWineController(IWineServices wineServices)
        {
            _wineServices= wineServices;
        }

        [HttpGet]
        public IActionResult GetWines()
        {
            return Ok(_wineServices.GetWines());
        }

        [HttpPost]
        public IActionResult AddWine(Wine wine)
        {
            return Ok(_wineServices.AddWine(wine));
        }

        [HttpGet("{id}")]
        public IActionResult GetWine(string id)
        {
            return Ok(_wineServices.GetWine(id));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteWine(string id)
        {
            _wineServices.DeleteWine(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateWine(Wine wine)
        {
            return Ok(_wineServices.UpdateWine(wine));
        }
    }
}