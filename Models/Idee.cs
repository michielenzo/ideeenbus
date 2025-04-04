namespace ideeenbus.Models;

using ideeenbus.Service.Dao;
using ideeenbus.Exceptions;
using System.ComponentModel.DataAnnotations;

public class Idee
{
    [Required]
    [StringLength(512)]
    public string onderwerp { get; set; }

    [Required]
    public string beschrijving { get; set; }

    public int? userId { get; set; }

    [StringLength(512)]
    public string? username { get; set; }

    [Required]
    public string type { get; set; }

    public DateTime? beginDatum { get; set; }

    public DateTime? eindDatum { get; set; }

    public string? duration
    {
        get
        {
            if (beginDatum.HasValue && eindDatum.HasValue)
            {
                TimeSpan timeDiff = eindDatum.Value - beginDatum.Value;
                if (timeDiff.TotalSeconds <= 0) return "Geen duur";
                return $"{timeDiff.Days} dag(en) {timeDiff.Hours} uur en {timeDiff.Minutes} minut(en)";
            }
            return null;
        }
    }

    public List<string> categories { get; set; } = new List<string>();

    public static Idee FromEntity(IdeeEntity entity) {
        Idee idee = new Idee();
        idee.onderwerp = entity.onderwerp;
        idee.beschrijving = entity.beschrijving;
        idee.userId = entity.userId;
        idee.username = entity.username;
        idee.type = entity.type;
        idee.beginDatum = entity.beginDatum;
        idee.eindDatum = entity.eindDatum;
        idee.categories = entity.categoryEntities.Select(c => c.Naam).ToList();
        return idee;
    }

    public void Validate() {
        List<string> errors = new List<string>();

        if (type == "uitje" && (beginDatum == null || eindDatum == null))
        {
            errors.Add("Een uitje moet een begin en einddatum hebben.");
        }
        if (type == "suggestie" && (beginDatum != null || eindDatum != null))
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