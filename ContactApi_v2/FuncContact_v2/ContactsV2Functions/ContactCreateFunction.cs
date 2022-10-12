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
    public static class ContactCreateFunction
    {

        [FunctionName("CreateContactFunc")]

#if DEBUG
        public static void CreateContactQueue([QueueTrigger(Constants.CreateQueue, Connection = "StorageStringConnection")] string contactToCreate, ILogger log)
        {
#else
        public static void CreateContactQueue([QueueTrigger(Constants.CreateQueue, Connection = SettingsHelper.StorageStringConnection)] string contactToCreate, ILogger log)
        {
#endif
            var contact = JsonConvert.DeserializeObject<Contact>(contactToCreate);
            var client = new HttpClient();

            using (var content = new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8, "application/json"))
            {
                try
                {
#if DEBUG
                    var result = client.PostAsync("https://localhost:44321/Contact/create-contact", content).Result;
#else
                    var result = client.PostAsync($"{SettingsHelper.GetAPIUrlString()}Contact/create-contact", content).Result;
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