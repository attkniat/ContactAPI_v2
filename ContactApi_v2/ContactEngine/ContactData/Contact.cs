using System.ComponentModel.DataAnnotations;

namespace ContactEngine.ContactData
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(11)]
        public string Phone { get; set; }
    }
}