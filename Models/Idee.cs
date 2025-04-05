namespace ideeenbus.Models;

using ideeenbus.Service.Entity;
using ideeenbus.Exceptions;
using System.ComponentModel.DataAnnotations;

public class Idee
{
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

    public List<string>? Categories { get; set; } = new List<string>();

    public string? Duration
    {
        get
        {
            if (BeginDatum.HasValue && EindDatum.HasValue)
            {
                TimeSpan timeDiff = EindDatum.Value - BeginDatum.Value;
                if (timeDiff.TotalSeconds <= 0) return "Geen duur";
                return $"{timeDiff.Days} dag(en) {timeDiff.Hours} uur en {timeDiff.Minutes} minut(en)";
            }
            return null;
        }
    }

    public static Idee FromEntity(IdeeEntity entity) {
        Idee idee = new()
        {
            Onderwerp = entity.Onderwerp,
            Beschrijving = entity.Beschrijving,
            UserId = entity.UserId,
            Username = entity.Username,
            Type = entity.Type,
            BeginDatum = entity.BeginDatum,
            EindDatum = entity.EindDatum,
            Categories = entity.CategoryEntities.Select(c => c.Naam).ToList()
        };

        return idee;
    }

    public void Validate() {
        List<string> errors = new List<string>();

        if (Type == "uitje" && (BeginDatum == null || EindDatum == null))
        {
            errors.Add("Een uitje moet een begin en einddatum hebben.");
        }
        if (Type == "suggestie" && (BeginDatum != null || EindDatum != null))
        {
            errors.Add("Een suggestie mag geen begin en einddatum hebben.");
        }

        // TODO validate if eindDatum is after beginDatum


        if (errors.Count > 0)
        {
            throw new BusinessLogicException(errors);
        }
    }
}