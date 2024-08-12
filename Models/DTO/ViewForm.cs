namespace Capsitech.Models.DTO
{
    public class ViewForm
    {
        public string userId { get; set; }
        public string userName {  get; set; }
        public string presentAddress { get; set; }
        public string mobileNumber { get; set; }
        public string email { get; set; }

        public ViewForm(ViewForm data)
        {
            this.userId = data.userId;
            this.userName = data.userName;
            this.presentAddress = data.presentAddress;
            this.mobileNumber = data.mobileNumber;
            this.email = data.email;
        }
    }
}
