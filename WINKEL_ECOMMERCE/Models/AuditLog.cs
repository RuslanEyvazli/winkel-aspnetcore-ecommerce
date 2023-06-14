using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WINKEL_ECOMMERCE.Models
{
    public class AuditLog
    {
        [Key]
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Path { get; set; }
        public bool IsHttps { get; set; }
        public string? QueryString { get; set; }
        public string? Method { get; set; }
        public string? Area { get; set; }
        public string? Controller { get; set; }
        public string? Action { get; set; }
        public string? StatusCode { get; set; }
        public DateTime RequestTime { get; set; }
        public DateTime ResponseTime { get; set; }

    }
}
