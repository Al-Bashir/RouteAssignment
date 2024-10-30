using C42_G01_MVC_Demo.DAL.Models;
using C42_G01_MVC01_Demo.PL.Settings;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML.Voice;

namespace C42_G01_MVC01_Demo.PL.Helpers
{
    public class TwilioSMSSetting : ITwilioSMSSetting
    {
        private readonly TwilioSMSSettings _options;

        public TwilioSMSSetting(IOptions<TwilioSMSSettings> options)
        {
            _options = options.Value;
        }
        public MessageResource SendSMS(SMS sms)
        {
            TwilioClient.Init(_options.AccountSID, _options.AuthToken);
            var result = MessageResource.Create(
                    body: sms.SMSBody,
                    from: new Twilio.Types.PhoneNumber(_options.PhoneNumber),
                    to: sms.PhoneNumber
                );
            return result;
        }
    }
}
