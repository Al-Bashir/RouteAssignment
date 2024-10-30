using C42_G01_MVC_Demo.DAL.Models;

namespace C42_G01_MVC01_Demo.PL.Helpers
{
    public interface IMailSetting
    {
        public void SendEmail(Email email);
    }
}
