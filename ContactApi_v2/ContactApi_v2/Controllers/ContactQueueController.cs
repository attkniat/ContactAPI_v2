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

        [HttpPost]
        [Route("get-contact-get-id-send-queue")]
        public async Task ContactGetByIdQueue([FromBody] int contactId)
        {
            try
            {
                var queueCliente = new QueueClient(ConstantsQueue.StorageAccountStr, ConstantsQueue.ContactQueueName);
                var jsonContact = JsonSerializer.Serialize(contactId);
                await queueCliente.SendMessageAsync(jsonContact);
            }
            catch (Exception ex)
            {
                throw new Exception($"Send message Error --->  {ex.Message}");
            }
        }

        [HttpPost]
        [Route("create-contact-send-queue")]
        public async Task CreateContactQueue([FromBody] Contact contact)
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

        [HttpPost]
        [Route("update-contact-send-queue")]
        public async Task UpdateContactQueue([FromBody] Contact contact)
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

        [HttpPost]
        [Route("delete-contact-send-queue")]
        public async Task DeleteContactQueue([FromBody] int contactId)
        {
            try
            {
                var queueCliente = new QueueClient(ConstantsQueue.StorageAccountStr, ConstantsQueue.ContactQueueName);
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