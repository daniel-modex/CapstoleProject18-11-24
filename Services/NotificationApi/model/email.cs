namespace NotificationApi.model
{
    public class EmailRequest
    {
        public string SendTo { get; set; }
        public string Name { get; set; }
        public string ReplyTo { get; set; }
        public bool IsHtml { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
