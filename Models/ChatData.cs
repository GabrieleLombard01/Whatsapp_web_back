namespace Whatsapp_web_back.Models
{
    public class ChatData
    {
        public UserModel User { get; set; }
        public List<UserModel> Users { get; set; }
        public List<ContactModel> Contacts { get; set; }
    }
}

