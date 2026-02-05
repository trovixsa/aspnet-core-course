using System.ComponentModel.DataAnnotations;

namespace ModelBindSample.Application
{
    public class ProductCreateDto
    {
        [Required]
        [Range(1,5, ErrorMessage = "the length must be less than 5")]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }
    }
}
