using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using FuncContact_v2.ConstantsFunc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System;

namespace FuncContact_v2.ContactsV2Functions
{
    public static class DeleteContactFunction
    {
        [FunctionName("DeleteContactFunc")]
        public static void DeleteContactQueue([QueueTrigger(Constants.DeleteQueue, Connection = "ConnStrFunc")] string contactIdToDelete, ILogger log)
        {
            var contactId = JsonConvert.DeserializeObject<int>(contactIdToDelete);

            var client = new HttpClient();

            using (var content = new StringContent(JsonConvert.SerializeObject(contactId), Encoding.UTF8, "application/json"))
            {
                try
                {
                    var result = client.DeleteAsync($"https://localhost:44321/Contact/delete-contact?contactId={contactId}").Result;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error in API calling --> {ex.Message}");
                }
            }

            log.LogInformation($"C# Queue trigger function processed: {contactIdToDelete}");
        }
    }
}