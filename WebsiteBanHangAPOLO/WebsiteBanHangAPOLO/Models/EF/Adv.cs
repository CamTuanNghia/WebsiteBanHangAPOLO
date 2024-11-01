using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteBanHangAPOLO.Models.EF
{
    [Table("tb_Adv")]
    public class Adv : CommonAbstract
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SeoTitle { get; set; }
        public string Descripttion { get; set; }
        public string Image { get; set; }
        public int Type { get; set; }
        public string Link { get; set; }
    }
}