using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebsiteBanHangAPOLO.Models.EF
{
    [Table("tb_New")]
    public class New : CommonAbstract
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required(ErrorMessage = "Tiêu đề tin không được để trống")]
        [StringLength(150, ErrorMessage = "Không Được Vượt 150 Ký Tự")]
        public string Title { get; set; }
        public string Alias { get; set; }
        public string CategoryId { get; set; }
        public string Descripttion { get; set; }
        [AllowHtml]
        public string Detail { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDecription { get; set; }
        public bool IsActive { get; set; }
        public string SeoKeywords { get; set; }
        public string Image { get; set; }
    }
}