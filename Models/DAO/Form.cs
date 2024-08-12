using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Capsitech.Models.DAO
{
    public enum hideFlag
    {
        yes = 1,
        no = 0
    }
    public class Form
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        private string Id;
        public required string userId { get; set; }
        public required string employeeName { get; set; }

        [BsonElement("fatherName")]
        public required string fathersName { get; set; }
        public required DateTime birthDate { get; set; }
        public required string mobileNumber { get; set; }
        public string? gender { get; set; }
        public string? bloodGroup { get; set; }
        public required string addharNumber { get; set; }
        public required string email { get; set; }
        public required string presentAddress { get; set; }
        public string? permanenetAdress { get; set; }
        public string? martial_Status { get; set; }
        public string? bankAccountNumber { get; set; }
        public string? bankName { get; set; }
        public string? ifscCode { get; set; }
        public string? bankAddress { get; set; }
        public required string panNo { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public required hideFlag isDeleted { get; set; }=hideFlag.no;
        public required hideFlag isModified { get; set; }=hideFlag.no;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; }=DateTime.Now;


        public Form()
        {
            
        }
        [SetsRequiredMembers]
        public Form(Form data)
        {
            this.userId = data.userId;
            this.isDeleted =data.isDeleted;
            this.employeeName = data.employeeName;
            this.CreatedBy = data.employeeName;
            this.UpdatedBy = data.employeeName;
            this.fathersName = data.fathersName;
            this.birthDate = data.birthDate;
            this.email = data.email;
            this.mobileNumber = data.mobileNumber;
            this.panNo = data.panNo;
            this.bloodGroup = data.bloodGroup;
            this.presentAddress = data.presentAddress;
            this.addharNumber = data.addharNumber;
            this.bankAccountNumber = data.bankAccountNumber;
            this.gender = data.gender;
            this.bankAddress = data.bankAddress;
            this.ifscCode = data.ifscCode;
            this.martial_Status = data.martial_Status;
            this.bankName = data.bankName;
            this.isModified = data.isModified;
        }
    }
}
