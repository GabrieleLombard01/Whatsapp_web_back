namespace Whatsapp_web_back.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public bool Visible { get; set; }
        public List<MessageModel> Messages { get; set; }
    }

}
