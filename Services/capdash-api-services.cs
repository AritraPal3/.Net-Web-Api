using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Capsitech.Services.Core;
using Capsitech.Models.DAO;
using Capsitech.Models.DTO;

namespace Capsitech.Services
{
    public class capdash_api_services
    {
        public readonly FormService _mongoFormServices;
        public readonly LogServices _mongoLogServices;

        public capdash_api_services(FormService mongoServices,LogServices mongoLogServices)
        {
            _mongoFormServices = mongoServices;
            _mongoLogServices = mongoLogServices;
        }
        public static string ShowParams(Form data)
        {
            var obtained = JsonSerializer.Serialize(data);
            if (true)
            {
                //show Data;
            }
            Console.WriteLine(obtained);
            return obtained;
        }

        public IEnumerable<Form>? GetSavedData(string id)
        {
            Console.WriteLine(id);
            return _mongoFormServices.GetData(id);
        }


        public void SaveFormData(Form data) {
            if (data.isModified==hideFlag.no)
            {
                _mongoFormServices.SaveForm(data);
                var log = new ChangeLogs(data);
                _mongoLogServices.CreateLog(log);
                Console.WriteLine("Data has been saved");
            }
            else
            {
                _mongoFormServices.EditForm(data);
                var log = new ChangeLogs(data);
                //Console.WriteLine(JsonSerializer.Serialize(log));
                _mongoLogServices.UpdateLog(log);
                Console.WriteLine("Data has been edited");
            }
            
        }
    }
}
