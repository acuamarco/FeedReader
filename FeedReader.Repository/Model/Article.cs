using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeedReader.Repository.Model
{
    [Table("Article")]
    public partial class Article
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        [Column(TypeName = "text")]
        public string Body { get; set; }

        [StringLength(150)]
        public string Image { get; set; }

        public int FeedId { get; set; }

        public virtual Feed Feed { get; set; }
    }
}
