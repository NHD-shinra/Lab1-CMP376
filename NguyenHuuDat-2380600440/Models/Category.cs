using System.ComponentModel.DataAnnotations;

namespace NguyenHuuDat_2380600440.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
    }
}
