using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using FuncContact_v2.ConstantsFunc;

namespace FuncContact_v2.ContactsV2Functions
{
    public static class ContactFunction
    {
        [FunctionName("Contact-Function")]
        public static void Run([QueueTrigger(Constants.QueueNameFunc, Connection = "ConnStrFunc")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
