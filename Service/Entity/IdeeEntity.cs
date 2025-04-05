namespace ideeenbus.Service.Entity;

using ideeenbus.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class IdeeEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    public string Id { get; set; }
    
    [Required]
    [StringLength(512)]
    public required string Onderwerp { get; set; }
    
    [Required]
    public required string Beschrijving { get; set; }

    public int? UserId { get; set; }

    [StringLength(512)]
    public string? Username { get; set; }

    [Required]
    public required string Type { get; set; }

    public DateTime? BeginDatum { get; set; }

    public DateTime? EindDatum { get; set; }

    public List<CategoryInIdeeEntity> CategoryInIdeeEntities { get; } = [];

    public List<CategorieEntity> CategoryEntities { get; set; } = [];

    public static IdeeEntity fromModel(Idee model) { 
        IdeeEntity entity = new IdeeEntity { 
            Onderwerp = model.onderwerp,
            Beschrijving = model.beschrijving,
            Type = model.type
        };

        entity.UserId = model.userId;
        entity.Username = model.username;
        entity.BeginDatum = model.beginDatum;
        entity.EindDatum = model.eindDatum;
        entity.CategoryEntities = !string.IsNullOrWhiteSpace(model.categories?.FirstOrDefault()) ? model.categories.First()
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.Trim('[', ']', '"'))
                .Select(c => new CategorieEntity { Naam = c })
                .ToList() : [];

        return entity;
    }
}