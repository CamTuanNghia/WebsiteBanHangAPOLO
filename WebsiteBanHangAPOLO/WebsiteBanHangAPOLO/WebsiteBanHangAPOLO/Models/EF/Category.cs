using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteBanHangAPOLO.Models.EF
{
    [Table("tb_Category")]
    public class Category : CommonAbstract
    {
        public Category()
        {
            this.News = new HashSet<New>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required(ErrorMessage = "Tên Danh Mục Không Được Để Trống")]
        [StringLength(150, ErrorMessage = "Không Được Vượt 150 Ký Tự")]
        public string Title { get; set; }
        public string Alias { get; set; }
        [StringLength(150, ErrorMessage = "Không Được Vượt 150 Ký Tự")]
        public string SeoTitle { get; set; }
        [StringLength(150, ErrorMessage = "Không Được Vượt 150 Ký Tự")]
        public string Descripttion { get; set; }
        [StringLength(150, ErrorMessage = "Không Được Vượt 150 Ký Tự")]
        public string SeoDecripttion { get; set; }
        [StringLength(150, ErrorMessage = "Không Được Vượt 150 Ký Tự")]
        public string SeoKeywords { get; set; }
        public bool IsActive { get; set; }
        public int Position { get; set; }
        public ICollection<New> News { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}