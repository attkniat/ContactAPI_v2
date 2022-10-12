using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using FuncContact_v2.ConstantsFunc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System;
using FuncContact_v2.UtilExtensions;

namespace FuncContact_v2.ContactsV2Functions
{
    public static class DeleteContactFunction
    {
        [FunctionName("DeleteContactFunc")]
#if DEBUG
        public static void DeleteContactQueue([QueueTrigger(Constants.DeleteQueue, Connection = "StorageStringConnection")] string contactIdToDelete, ILogger log)
        {
#else
        public static void DeleteContactQueue([QueueTrigger(Constants.DeleteQueue, Connection = SettingsHelper.StorageStringConnection)] string contactIdToDelete, ILogger log)
        {
#endif
            var contactId = JsonConvert.DeserializeObject<int>(contactIdToDelete);

            var client = new HttpClient();

            using (var content = new StringContent(JsonConvert.SerializeObject(contactId), Encoding.UTF8, "application/json"))
            {
                try
                {
#if DEBUG
                    var result = client.DeleteAsync($"https://localhost:44321/Contact/delete-contact?contactId={contactId}").Result;
#else
                    var result = client.DeleteAsync($"{SettingsHelper.GetAPIUrlString()}Contact/delete-contact?contactId={contactId}").Result;
#endif
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