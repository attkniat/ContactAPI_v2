using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using FuncContact_v2.ConstantsFunc;
using Newtonsoft.Json;
using FuncContact_v2.ContactModel;
using System.Net.Http;
using System.Text;
using System;

namespace FuncContact_v2.ContactsV2Functions
{
    public static class ContactFunction
    {
        [FunctionName("CreateContactFunc")]
        public static void CreateContactQueue([QueueTrigger(Constants.QueueNameFunc, Connection = "ConnStrFunc")] string contactToCreate, ILogger log)
        {
            var contact = JsonConvert.DeserializeObject<Contact>(contactToCreate);
            var client = new HttpClient();

            using (var content = new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8, "application/json"))
            {
                try
                {
                    var result = client.PostAsync("https://localhost:44321/Contact/create-contact", content).Result;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error in API calling --> {ex.Message}");
                }
            }

            log.LogInformation($"C# Queue trigger function processed: {contact}");
        }
    }
}