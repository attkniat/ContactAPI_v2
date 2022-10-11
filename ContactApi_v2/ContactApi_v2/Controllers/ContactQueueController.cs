using Azure.Storage.Queues;
using ContactApi_v2.Constantes;
using ContactEngine.ContactModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace ContactApi_v2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactQueueController : ControllerBase
    {
        [HttpPost]
        [Route("get-all-send-queue")]
        public async Task ContactGetAllQueue([FromBody] Contact contact)
        {
            try
            {
                var queueCliente = new QueueClient(ConstantsQueue.StorageAccountStr, ConstantsQueue.ContactQueueName);
                var jsonContact = JsonSerializer.Serialize(contact);
                await queueCliente.SendMessageAsync(jsonContact);
            }
            catch (Exception ex)
            {
                throw new Exception($"Send message Error --->  {ex.Message}");
            }
        }
    }
}