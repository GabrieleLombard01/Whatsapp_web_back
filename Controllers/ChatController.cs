using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Whatsapp_web_back.Models;

namespace Whatsapp_web_back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private static ChatData chatData = GetSampleChatData();

        [HttpGet]
        public IActionResult GetChatData()
        {
            return Ok(chatData);
        }

        [HttpGet("{contactId}/messages")]
        public IActionResult GetContactMessages(int contactId)
        {
            ContactModel contact = chatData.Contacts.Find(c => c.Id == contactId);
            if (contact == null)
            {
                return NotFound($"Contact with ID {contactId} not found.");
            }

            return Ok(contact.Messages);
        }


        [HttpPost("addMessage/{contactId}")]
        public IActionResult AddMessage(int contactId, [FromBody] MessageModel newMessage)
        {
            ContactModel contact = chatData.Contacts.Find(c => c.Id == contactId);
            if (contact == null)
            {
                return NotFound($"Contact with ID {contactId} not found.");
            }

            // Aggiungi il nuovo messaggio alla lista dei messaggi del contatto
            newMessage.Id = contact.Messages.Count + 1;
            newMessage.Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            contact.Messages.Add(newMessage);

            return Ok(chatData);
        }

        private static ChatData GetSampleChatData()
        {
            return new ChatData
            {
                User = new UserModel { Name = "Gabriele Lombardo", Avatar = "https://e7.pngegg.com/pngimages/799/987/png-clipart-computer-icons-avatar-icon-design-avatar-heroes-computer-wallpaper-thumbnail.png" },
                Contacts = new List<ContactModel>
            {
                new ContactModel
                {
                    Id = 1,
                    Name = "Michele",
                    Avatar = "https://images.unsplash.com/photo-1527980965255-d3b416303d12?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nnx8YXZhdGFyfGVufDB8fDB8fHww",
                    Visible = true,
                    Messages = new List<MessageModel>
                    {
                        new MessageModel { Id = 1, Date = "10/01/2020 15:30:55", Message = "Hai portato a spasso il cane?", Status = "sent" },
                        new MessageModel { Id = 2, Date = "10/01/2020 15:50:00", Message = "Ricordati di stendere i panni", Status = "sent" },
                        new MessageModel { Id = 3, Date = "10/01/2020 16:15:22", Message = "Tutto fatto!", Status = "received" }
                    }
                },
                new ContactModel
                {
                    Id = 2,
                    Name = "Fabio",
                    Avatar = "https://images.unsplash.com/photo-1633332755192-727a05c4013d?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8OHx8YXZhdGFyfGVufDB8fDB8fHww",
                    Visible = true,
                    Messages = new List<MessageModel>
                    {
                        new MessageModel { Id = 1, Date = "10/01/2020 15:30:55", Message = "Ciao come stai?", Status = "sent" },
                        new MessageModel { Id = 2, Date = "10/01/2020 15:50:00", Message = "Bene grazie! Stasera ci vediamo?", Status = "received" },
                        new MessageModel { Id = 3, Date = "10/01/2020 16:15:22", Message = "Mi piacerebbe ma devo andare a fare la spesa.", Status = "sent" }
                    }
                },
                new ContactModel
                {
                    Id = 3,
                    Name = "Samuele",
                    Avatar = "https://previews.123rf.com/images/captainvector/captainvector1509/captainvector150901626/45372748-cameriere.jpg",
                    Visible = true,
                    Messages = new List<MessageModel>
                    {
                        new MessageModel { Id = 1, Date = "10/01/2020 15:30:55", Message = "La Marianna va in campagna", Status = "received" },
                        new MessageModel { Id = 2, Date = "10/01/2020 15:50:00", Message = "Sicuro di non aver sbagliato chat?", Status = "sent" },
                        new MessageModel { Id = 3, Date = "10/01/2020 16:15:22", Message = "Ah scusa!", Status = "received" }
                    }
                },
                new ContactModel
                {
                    Id = 4,
                    Name = "Alessandro B.",
                    Avatar = "https://images.unsplash.com/photo-1628157588553-5eeea00af15c?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTl8fGF2YXRhcnxlbnwwfHwwfHx8MA%3D%3D",
                    Visible = true,
                    Messages = new List<MessageModel>
                    {
                        new MessageModel { Id = 1, Date = "10/01/2020 15:30:55", Message = "Lo sai che ha aperto una nuova pizzeria?", Status = "sent" },
                        new MessageModel { Id = 2, Date = "10/01/2020 15:50:00", Message = "Si, ma preferirei andare al cinema", Status = "received" }
                    }
                },
                new ContactModel
                {
                    Id = 5,
                    Name = "Alessandro L.",
                    Avatar = "https://previews.123rf.com/images/captainvector/captainvector1601/captainvector160106093/51362298-concierge.jpg",
                    Visible = true,
                    Messages = new List<MessageModel>
                    {
                        new MessageModel { Id = 1, Date = "10/01/2020 15:30:55", Message = "Ricordati di chiamare la nonna", Status = "sent" },
                        new MessageModel { Id = 2, Date = "10/01/2020 15:50:00", Message = "Va bene, stasera la sento", Status = "received" },
                    }
                },
                new ContactModel
                {
                    Id = 6,
                    Name = "Claudia",
                    Avatar = "https://previews.123rf.com/images/captainvector/captainvector1509/captainvector150901022/45371986-clown.jpg",
                    Visible = true,
                    Messages = new List<MessageModel>
                    {
                        new MessageModel { Id = 1, Date = "10/01/2020 15:30:55", Message = "Ciao Claudia, hai novità?", Status = "sent" },
                        new MessageModel { Id = 2, Date = "10/01/2020 15:50:00", Message = "Non ancora", Status = "received" },
                        new MessageModel { Id = 3, Date = "10/01/2020 16:15:22", Message = "Nessuna nuova, buona nuova", Status = "sent" }
                    }
                },
                new ContactModel
                {
                    Id = 7,
                    Name = "Federico",
                    Avatar = "https://previews.123rf.com/images/captainvector/captainvector1508/captainvector150803886/43310506-artista.jpg",
                    Visible = true,
                    Messages = new List<MessageModel>
                    {
                        new MessageModel { Id = 1, Date = "10/01/2020 15:30:55", Message = "Fai gli auguri a Martina che è il suo compleanno!", Status = "sent" },
                        new MessageModel { Id = 2, Date = "10/01/2020 15:50:00", Message = "Grazie per avermelo ricordato, le scrivo subito!", Status = "received" },
                    }
                },
                new ContactModel
                {
                    Id = 8,
                    Name = "Davide",
                    Avatar = "https://images.unsplash.com/photo-1640951613773-54706e06851d?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mjh8fGF2YXRhcnxlbnwwfHwwfHx8MA%3D%3D",
                    Visible = true,
                    Messages = new List<MessageModel>
                    {
                        new MessageModel { Id = 1, Date = "10/01/2020 15:30:55", Message = "Ciao, andiamo a mangiare la pizza stasera?", Status = "received" },
                        new MessageModel { Id = 2, Date = "10/01/2020 15:50:00", Message = "No, l'ho già mangiata ieri, ordiniamo sushi!", Status = "sent" },
                        new MessageModel { Id = 3, Date = "10/01/2020 16:15:22", Message = "OK!!", Status = "received" }
                    }
                },
            }
            };
        }
    }
}
