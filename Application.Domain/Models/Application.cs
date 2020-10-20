namespace Application.Models.Application
{
    public class Application
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string PathLocal { get; set; }
        public bool DebuggingMode { get; set; }

        public Application()
        {

        }

        public Application(int Id, string Url, string PathLocal, bool DebuggingMode)
        {
            this.Id = Id;
            this.Url = Url;
            this.PathLocal = PathLocal;
            this.DebuggingMode = DebuggingMode;
        }
    }
}
