using FuncContact_v2.ConstantsFunc;
using Microsoft.Azure.WebJobs;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FuncContact_v2.ContactsRepository
{
    public class AdminQueueService
    {
        public readonly string _connStr;
        public List<string> queuesFunction = new List<string>() { Constants.CreateQueue, Constants.UpdateQueue, Constants.DeleteQueue };

        public AdminQueueService(string connStr)
        {
            _connStr = connStr;
        }

        public void CreateQueuesFunction()
        {
            var account = CloudStorageAccount.Parse(_connStr);
            var client = account.CreateCloudQueueClient();
            var tipoFunction = typeof(FunctionNameAttribute);

            var tasks = new List<Task>();

            foreach (var item in queuesFunction)
            {
                var queue = client.GetQueueReference(item.ToLower());

                var task = Task.Run(() =>
                {
                    try
                    {
                        queue.CreateIfNotExistsAsync().GetAwaiter().GetResult();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Error to create the queue named: '{item.ToLower()}'", ex);
                    }

                });

                tasks.Add(task);
            }
        }
    }
}