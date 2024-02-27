﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }


        [HttpPost("add")]
        public IActionResult Add(Message message)
        {
            _messageService.Add(message);
            return Ok(message);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var messages= _messageService.GetAll();
            return Ok(messages);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var messageToDelete= _messageService.GetById(id);
            _messageService.Delete(id);
            return Ok(messageToDelete);
        }

        [HttpPut("update")]
        public IActionResult Put(int id)
        {
            var messageToUpdate = _messageService.GetById(id);

            return Ok(messageToUpdate);
        }
    }
}