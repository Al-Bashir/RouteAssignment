using C42_G01_MVC_Demo.DAL.Models;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML.Voice;

namespace C42_G01_MVC01_Demo.PL.Helpers
{
    public interface ITwilioSMSSetting
    {
        public MessageResource SendSMS(SMS sms);
    }
}
