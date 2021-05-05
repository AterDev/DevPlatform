using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity
{
    [Table("ArticleCatalog")]
    public class ArticleCatalog : Catalog
    {
        /// <summary>
        /// 该目录的文章
        /// </summary>
        public List<Article> Articles { get; set; }
        /// <summary>
        /// 父目录
        /// </summary>
        public ArticleCatalog Parent { get; set; }
        /// <summary>
        /// 所属用户
        /// </summary>
        [ForeignKey("AccountId")]
        public Account Account { get; set; }
        /// <summary>
        /// 子目录
        /// </summary>
        public List<ArticleCatalog> Catalogs { get; set; }

    }
}