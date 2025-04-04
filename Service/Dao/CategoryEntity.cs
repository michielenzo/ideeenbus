namespace ideeenbus.Service.Dao;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class CategorieEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Naam { get; set; }

    public List<CategoryInIdeeEntity> categoryInIdeeEntities { get; } = new List<CategoryInIdeeEntity>();
    public List<IdeeEntity> ideeEntities { get; } = new List<IdeeEntity>();
}