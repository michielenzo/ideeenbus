namespace ideeenbus.Service.Entity;

using ideeenbus.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class IdeeEntity
{
    #pragma warning disable CS8618 // Geen required keyword omdat deze waarde auto generated is.
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

    public static IdeeEntity FromModel(Idee model) {
        IdeeEntity entity = new()
        {
            Onderwerp = model.Onderwerp,
            Beschrijving = model.Beschrijving,
            Type = model.Type,
            UserId = model.UserId,
            Username = model.Username,
            BeginDatum = model.BeginDatum,
            EindDatum = model.EindDatum,
            CategoryEntities = !string.IsNullOrWhiteSpace(model.Categories?.FirstOrDefault()) ? model.Categories.First()
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(c => c.Trim('[', ']', '"'))
                    .Select(c => new CategorieEntity { Naam = c })
                    .ToList() : []
        };

        return entity;
    }
}