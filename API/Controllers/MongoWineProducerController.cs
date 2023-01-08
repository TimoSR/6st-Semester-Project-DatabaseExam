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
    public class MongoWineProducerController: ControllerBase
    {
        private readonly IWineProducerServices _wineProducerServices;

        public MongoWineProducerController(IWineProducerServices wineProducerServices)
        {
            _wineProducerServices= wineProducerServices;
        }

        [HttpGet]
        public IActionResult GetProducers()
        {
            return Ok(_wineProducerServices.GetProducers());
        }

        [HttpPost]
        public IActionResult AddProducer(WineProducer producer)
        {
            return Ok(_wineProducerServices.AddProducer(producer));
        }
        
        [HttpGet("{id}")]
        public IActionResult GetProducer(string id)
        {
            return Ok(_wineProducerServices.GetProducer(id));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProducer(string id)
        {
            _wineProducerServices.DeleteProducer(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateProducer(WineProducer producer)
        {
            return Ok(_wineProducerServices.UpdateProducer(producer));
        }
    }
}