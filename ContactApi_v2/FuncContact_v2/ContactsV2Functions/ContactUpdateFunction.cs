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
    public static class ContactUpdateFunction
    {
        [FunctionName("UpdateContactFunc")]
        public static void UpdateContactQueue([QueueTrigger(Constants.UpdateQueue, Connection = "ConnStrFunc")] string contactToUpdate, ILogger log)
        {
            var contact = JsonConvert.DeserializeObject<Contact>(contactToUpdate);
            var client = new HttpClient();

            using (var content = new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8, "application/json"))
            {
                try
                {
                    var result = client.PutAsync("https://localhost:44321/Contact/update-contact", content).Result;
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