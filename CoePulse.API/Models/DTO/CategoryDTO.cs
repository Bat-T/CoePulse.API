namespace CoePulse.API.Models.DTO
{
    public record CategoryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UrlHandle { get; set; }

    }
}
