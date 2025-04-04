namespace ideeenbus.Service.Dao;

using ideeenbus.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class IdeeEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }
    
    public string onderwerp { get; set; }

    public string beschrijving { get; set; }

    public int? userId { get; set; }

    public string? username { get; set; }

    // TODO make enum?
    public string type { get; set; }

    public string? beginDatum { get; set; }

    public string? eindDatum { get; set; }

    // TODO make list
    public string categories { get; set; }

    public static IdeeEntity fromModel(Idee model) { 
        IdeeEntity entity = new IdeeEntity();
        entity.onderwerp = model.onderwerp;
        entity.beschrijving = model.beschrijving;
        entity.userId = model.userId;
        entity.username = model.username;
        entity.type = model.type;
        entity.beginDatum = model.beginDatum;
        entity.eindDatum = model.eindDatum;
        entity.categories = model.categories;
        return entity;
    }
}