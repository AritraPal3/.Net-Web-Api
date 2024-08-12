using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Security.Cryptography.X509Certificates;

namespace Capsitech.Models.DAO
{
    public class ChangeLogs
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        private string _id;
        public string userId;
        public string CreatedBy;
        public string UpdatedBy;
        public DateTime? CreatedDate;
        public DateTime? UpdatedDate;

        public ChangeLogs() {}
        public ChangeLogs(Form data) 
        {
            this.CreatedDate = data.CreatedDate;
            this.userId = data.userId;
            this.CreatedBy=data.CreatedBy;
            this.UpdatedBy=data.UpdatedBy;
        }
    }

}
