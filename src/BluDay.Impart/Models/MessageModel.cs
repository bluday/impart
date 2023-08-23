namespace BluDay.Impart.Models
{
    public sealed class MessageModel : Common.Domain.Models.BluModel
    {
        private bool _read;

        private string _content;

        private Windows.UI.Xaml.HorizontalAlignment _side;

        public bool Read
        {
            get => _read;
            set => SetProperty(ref _read, value);
        }

        public string Content
        {
            get => _content;
            set => SetProperty(ref _content, value);
        }

        public System.Guid? ChatId { get; set; }

        public System.Guid? UserId { get; set; }

        public Windows.UI.Xaml.HorizontalAlignment Side
        {
            get => _side;
            set => SetProperty(ref _side, value);
        }

        public MessageModel(string content)
        {
            Content = content;
        }
    }
}