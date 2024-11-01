using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteBanHangAPOLO.Models.EF
{
    [Table("tb_Post")]
    public class Post:CommonAbstract
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Title { get; set; }
        public string CategoryId { get; set; }
        public string Descripttion { get; set; }
        public string Detail { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDecription { get; set; }
        public string SeoKeywords { get; set; }
        public string Image { get; set; }
    }
}