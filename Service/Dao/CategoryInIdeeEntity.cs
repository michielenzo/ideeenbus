namespace ideeenbus.Service.Dao;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

[PrimaryKey(nameof(CategoryEntityId), nameof(IdeeEntityId))]
public class CategoryInIdeeEntity 
{
    public int CategoryEntityId { get; set; }

    public int IdeeEntityId { get; set; }

    // Skip navigations to skip over joins
    public CategorieEntity CategorieEntity { get; set; } = null!;
    public IdeeEntity IdeeEntity { get; set; } = null!;
}