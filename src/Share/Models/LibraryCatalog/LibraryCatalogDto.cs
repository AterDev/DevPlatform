using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Share.Models
{
    public class LibraryCatalogDto
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Type { get; set; }
        public short Sort { get; set; }
        public short Level { get; set; }
        [ForeignKey("ParentId")]
        public LibraryCatalog Parent { get; set; }
        /// <summary>
        /// 所属用户
        /// </summary>
        [ForeignKey("AccountId")]
        // public AccountDto Account { get; set; }
        public Guid AccountId { get; set; }
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public Status Status { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public DateTimeOffset UpdatedTime { get; set; }

    }
}