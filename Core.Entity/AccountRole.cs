using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Core.Entity
{
    /// <summary>
    /// 用户角色表
    /// </summary>
    public partial class AccountRole : EntityBase
    {
        [ForeignKey("AccountId")]
        public Account Account { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
        public Guid AccountId { get; set; }
        public Guid RoleId { get; set; }
    }
}
