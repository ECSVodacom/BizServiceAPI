using System.ComponentModel.DataAnnotations;

namespace BizServiceApi.Database.Repository.Models
{
    public partial class Authenticate
    {
        [Key]
        public int Id { get; set; }
        public string LoginId { get; set; } = null!;
        public string Hash { get; set; } = null!;
    }
}
