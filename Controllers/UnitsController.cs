using DecoratedUnitOfWork.Models;
using DecoratedUnitOfWork.Services.ItemOneServices;
using Microsoft.AspNetCore.Mvc;

namespace DecoratedUnitOfWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private readonly IItemOneService service;
        private readonly GetAllItems itemsService;

        public UnitsController(
            IItemOneService service, 
            GetAllItems itemsService)
        {
            this.service = service;
            this.itemsService = itemsService;
        }

        [HttpGet]
        public ActionResult ExecuteWithUnitOfWork()
        {
            var item = new ItemOne { id = Guid.NewGuid() };
            service.Execute(item);
            
            return Ok();
        }

        [HttpGet("all")]
        public ActionResult GetItems()
        {
            return Ok(itemsService.GetItems());
        }
    }
}
