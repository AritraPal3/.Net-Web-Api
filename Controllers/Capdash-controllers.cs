using Microsoft.AspNetCore.Mvc;
using Capsitech.Services;
using Capsitech.Services.Core;
using Capsitech.Models.DAO;
using Capsitech.Models.DTO;

namespace Capsitech.Controllers
{

    [ApiController]
    [Route("api")]
    public class Capdash:ControllerBase
    {
        public readonly FormService _mongoFormServices;
        public readonly LogServices _mongoLogServices;
        public capdash_api_services services;
        public Capdash(FormService mongoFormServices,LogServices mongoLogService) { 
            _mongoFormServices = mongoFormServices;
            _mongoLogServices = mongoLogService;
            services = new capdash_api_services(mongoFormServices,mongoLogService);
        }

        [HttpPost("showRequestBody")]
        public ActionResult? Post([FromBody] Form data)
        {
            try
            {
                var Data = new Form(data);
                services.SaveFormData(Data);
                return Ok(1);
            }
            catch(Exception e) {
                Console.WriteLine(e);
                return null;
            }
        }

        [HttpGet("demoSavedData/")]
        public IEnumerable<Form>? SavedData(string id="")
        {
            //var result1= services.GetSavedData(id: id) as IEnumerable<ViewForm>; // not getting data in the form of ViewForm
            var result2 = services.GetSavedData(id);
            return result2;
        }
    }
}
