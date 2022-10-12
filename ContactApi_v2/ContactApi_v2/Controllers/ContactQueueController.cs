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
        [Route("create-contact-send-queue")]
        public async Task CreateContactQueue([FromBody] Contact contact)
        {
            try
            {
                var queueCliente = new QueueClient(ConstantsQueue.StorageAccountStr, ConstantsQueue.CreateQueue, new QueueClientOptions
                {
                    MessageEncoding = QueueMessageEncoding.Base64
                });

                var stringContact = JsonSerializer.Serialize(contact);
                await queueCliente.SendMessageAsync(stringContact);
            }
            catch (Exception ex)
            {
                throw new Exception($"Send message Error --->  {ex.Message}");
            }
        }

        [HttpPut]
        [Route("update-contact-send-queue")]
        public async Task UpdateContactQueue([FromBody] Contact contact)
        {
            try
            {
                var queueCliente = new QueueClient(ConstantsQueue.StorageAccountStr, ConstantsQueue.UpdateQueue, new QueueClientOptions
                {
                    MessageEncoding = QueueMessageEncoding.Base64
                });

                var jsonContact = JsonSerializer.Serialize(contact);
                await queueCliente.SendMessageAsync(jsonContact);
            }
            catch (Exception ex)
            {
                throw new Exception($"Send message Error --->  {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("delete-contact-send-queue")]
        public async Task DeleteContactQueue(int contactId)
        {
            try
            {
                var queueCliente = new QueueClient(ConstantsQueue.StorageAccountStr, ConstantsQueue.DeleteQueue, new QueueClientOptions
                {
                    MessageEncoding = QueueMessageEncoding.Base64
                });

                var jsonContact = JsonSerializer.Serialize(contactId);
                await queueCliente.SendMessageAsync(jsonContact);
            }
            catch (Exception ex)
            {
                throw new Exception($"Send message Error --->  {ex.Message}");
            }
        }
    }
}