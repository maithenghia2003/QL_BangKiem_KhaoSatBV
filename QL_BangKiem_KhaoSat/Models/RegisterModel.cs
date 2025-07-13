using System.ComponentModel.DataAnnotations;

namespace QL_BangKiem_KhaoSat.Models
{
    public class RegisterModel
    {
        [Required]
        public string HoTen { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(6)]
        public string MatKhau { get; set; }

        [Required]
        public int VaiTroId { get; set; }
    }
}
