using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Capsitech.Models;
using System.Text.Json;
using MongoDB.Driver.Linq;
using Capsitech.Models.DTO;
using Capsitech.Models.DAO;
using System.Collections.Generic;

namespace Capsitech.Services.Core
{
    public class FormService
    {
        private readonly IMongoCollection<Form> _form1Collection;
        //Configuring the Mongodb Database for performing operations
        public FormService(IOptions<FormDataBaseSettings> mongoDBSettings)
        {
            var client = new MongoClient(mongoDBSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _form1Collection = database.GetCollection<Form>(mongoDBSettings.Value.CapdashCollections);
        }

        public async void SaveForm(Form form)
        {
            var jsonData = JsonSerializer.Serialize(form);
            Console.WriteLine(jsonData);
            //setting userId
            form.userId=Guid.NewGuid().ToString();
            await _form1Collection.InsertOneAsync(form);
            return;
        }
        public IEnumerable<Form>? GetData(string id)
        {
            var query = _form1Collection.AsQueryable();
            try
            {
                if (id == ""||id==null)
                {
                    return from x in query as IEnumerable<Form>
                           where x.isDeleted!=hideFlag.yes
                                 select x;
                }
                else
                {
                    return from x in query as IEnumerable<Form>
                                     where x.userId==id 
                                     where x.isDeleted != hideFlag.yes
                                 select x;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); return null; }
        }

        public async void EditForm(Form form) {
            /*var jsonData = JsonSerializer.Serialize(form);
            Console.WriteLine(jsonData);*/
            var filter = Builders<Form>.Filter.Eq(s => s.userId, form.userId);
            if (form.isDeleted == hideFlag.yes)
            {
                var update = Builders<Form>.Update.Set(s => s.isDeleted, hideFlag.yes);
                await _form1Collection.UpdateOneAsync(filter, update);
            }
            else
            {
                var update = Builders<Form>.Update
                    .Set(s => s.employeeName, form.employeeName)
                    .Set(s => s.email, form.email)
                    .Set(s => s.addharNumber, form.addharNumber)
                    .Set(s => s.mobileNumber, form.mobileNumber)
                    .Set(s => s.birthDate, form.birthDate)
                    .Set(s => s.bloodGroup, form.bloodGroup)
                    .Set(s => s.panNo, form.panNo)
                    .Set(s => s.presentAddress, form.presentAddress)
                    .Set(s => s.fathersName, form.fathersName)
                    .Set(s => s.isModified, hideFlag.no);

                await _form1Collection.UpdateOneAsync(filter, update);
            } 
            return;
        }
    }

}
