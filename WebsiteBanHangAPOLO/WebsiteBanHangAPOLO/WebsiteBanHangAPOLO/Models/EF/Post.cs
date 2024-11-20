using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebsiteBanHangAPOLO.Models.EF
{
    [Table("tb_Post")]
    public class Post:CommonAbstract
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Alias { get; set; }
        public string CategoryId { get; set; }
        [StringLength(500)]
        public string Descripttion { get; set; }
        [AllowHtml]
        public string Detail { get; set; }
        [StringLength(250)]
        public string SeoTitle { get; set; }
        [StringLength(250)]
        public string SeoDecription { get; set; }
        public bool IsActive { get; set; }
        public string SeoKeywords { get; set; }
        public string Image { get; set; }
    }
}