namespace ideeenbus.Service.Entity;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class CategorieEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public required string Naam { get; set; }

    public List<CategoryInIdeeEntity> CategoryInIdeeEntities { get; } = [];
    public List<IdeeEntity> IdeeEntities { get; } = [];
}