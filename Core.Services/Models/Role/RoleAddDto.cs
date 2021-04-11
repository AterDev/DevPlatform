using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Services.Models;
using GT.Agreement.Models;
using Core.Entity;
namespace Core.Services.Models
{
    public class RoleAddDto
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        [MaxLength(50)]
        public string Name { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        [MaxLength(30)]
        public string Icon { get; set; }
    
    }
}