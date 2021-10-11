namespace BulaDigital.WEB.Models
{
    public class AnvisaResponse
    {
        public List<Content> content { get; set; }
        public int totalElements { get; set; }
        public int totalPages { get; set; }
        public bool last { get; set; }
        public int numberOfElements { get; set; }
        public object sort { get; set; }
        public bool first { get; set; }
        public int size { get; set; }
        public int number { get; set; }
    }
}
