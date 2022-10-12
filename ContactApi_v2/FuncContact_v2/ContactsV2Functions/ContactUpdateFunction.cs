using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using FuncContact_v2.ConstantsFunc;
using Newtonsoft.Json;
using FuncContact_v2.ContactModel;
using System.Net.Http;
using System.Text;
using System;
using FuncContact_v2.UtilExtensions;

namespace FuncContact_v2.ContactsV2Functions
{
    public static class ContactUpdateFunction
    {
        [FunctionName("UpdateContactFunc")]

#if DEBUG
        public static void UpdateContactQueue([QueueTrigger(Constants.UpdateQueue, Connection = "StorageStringConnection")] string contactToUpdate, ILogger log)
        {
#else
        public static void UpdateContactQueue([QueueTrigger(Constants.UpdateQueue, Connection = SettingsHelper.StorageStringConnection)] string contactToUpdate, ILogger log)
        {
#endif
            var contact = JsonConvert.DeserializeObject<Contact>(contactToUpdate);
            var client = new HttpClient();

            using (var content = new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8, "application/json"))
            {
                try
                {
#if DEBUG
                    var result = client.PutAsync("https://localhost:44321/Contact/update-contact", content).Result;
#else
                    var result = client.PutAsync($"{SettingsHelper.GetAPIUrlString()}Contact/update-contact", content).Result;
#endif
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