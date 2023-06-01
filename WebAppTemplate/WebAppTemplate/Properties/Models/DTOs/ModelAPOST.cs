using System.ComponentModel.DataAnnotations;

namespace WebAppTemplate.Properties.Models.DTOs; 

public class ModelAPOST {
    //Przy modelach dla dodawanych danych, warto dodać ograniczenia
    [Required]
    [MaxLength(20)]
    public string Name { get; set; } = null!;
    [Required]
    [MaxLength(20)]
    public string Surname { get; set; } = null!;
}