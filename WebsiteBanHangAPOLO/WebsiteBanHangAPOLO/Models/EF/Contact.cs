using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteBanHangAPOLO.Models.EF
{
    [Table("tb_Contact")]
    public class Contact : CommonAbstract
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên danh mục không để trống")]
        [StringLength(250, ErrorMessage = "Tên không vượt quá 250 kí tự")]
        public string Name { get; set; }
        [StringLength(250, ErrorMessage = "Tên không vượt quá 250 kí tự")]
        public string Email { get; set; }
        [StringLength(4000, ErrorMessage = "Email không vượt quá 4000 kí tự")]
        public string Message { get; set; }
        public bool IsRead { get; set; }

    }
}