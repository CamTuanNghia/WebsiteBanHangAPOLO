using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteBanHangAPOLO.Models.EF
{
    [Table("tb_ProductSubCategory")]
    public class ProductSubCategory : CommonAbstract
    {
        public ProductSubCategory()
        {
            this.Products = new HashSet<Product>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Tên danh mục con không được để trống")]
        [StringLength(150, ErrorMessage = "Tên danh mục không được vượt quá 150 ký tự")]
        public string Title { get; set; }

        public string Alias { get; set; }

        [StringLength(250)]
        public string Descripttion { get; set; }
        public string Icon { get; set; }

        [StringLength(250)]
        public string SeoTitle { get; set; }

        [StringLength(500)]
        public string SeoDescription { get; set; }

        [StringLength(200)]
        public string SeoKeywords { get; set; }
        [ForeignKey("ProductCategory")]
        public int ParentCategoryID { get; set; }
        public virtual ProductCategory ProductCategory { get; set; } 
        public ICollection<Product> Products { get; set; }
    }
}