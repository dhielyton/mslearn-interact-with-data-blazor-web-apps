
using System.ComponentModel.DataAnnotations;

namespace BlazingPizza
{
    public class Address
    {
        public virtual int Id { get; set; }

        [Required, MinLength(3, ErrorMessage = "Please usae a Name bigger than 3 letters"), MaxLength(100, ErrorMessage = "Please user a Name less than 100 letters")]
        public virtual string Name { get; set; }

        [Required, MinLength(5, ErrorMessage = "Please use a Address bigger than 5 letters"), MaxLength(100, ErrorMessage = "Please user a Address less than 100 letters")]
        public virtual string Line1 { get; set; }
        [MaxLength(100)]
        public virtual string Line2 { get; set; }
        [Required, MinLength(3, ErrorMessage = "Please usae a City bigger than 3 letters"), MaxLength(50, ErrorMessage = "Please user a City less than 50 letters")]
        public virtual string City { get; set; }
        [Required, MinLength(3, ErrorMessage = "Please usae a Region bigger than 3 letters"), MaxLength(20, ErrorMessage = "Please user a Region less than 20 letters")]
        public virtual string Region { get; set; }

        [Required, RegularExpression(@"^([0-9]{5})$", ErrorMessage = "Please use a valid Postal Code with five numbers.")]
        public virtual string PostalCode { get; set; }
    }
}
