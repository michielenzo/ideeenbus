using Microsoft.AspNetCore.Mvc;
using ideeenbus.Models;
using ideeenbus.Service;
using ideeenbus.Service.Dao;
using Microsoft.EntityFrameworkCore;
using ideeenbus.Exceptions;
using ideeenbus.Controllers.Dto;


namespace ideeenbus.Controllers;

[ApiController]
[Route("IdeeenController/")]
public class IdeeenController: ControllerBase {

    // Todo use dependency injection here i.c.m adapter pattern for data storage.
    // the adapter pattern will make it easy to adapt to another storage method.
    private DatabaseContext _context = new DatabaseContext();

    [HttpPost]
    [Route("SubmitForm")]
    public async Task<IActionResult> SubmitForm([FromForm] Idee idee)
    {
        try
        {
            idee.Validate();

            _context.Add(IdeeEntity.fromModel(idee));
            await _context.SaveChangesAsync();

            // TODO sort based on creation DateTime descending from the latest.
            List<IdeeEntity> ideeEntities = await _context.Ideeen
                .Include(i => i.categoryEntities)
                .ToListAsync();

            return Ok(new SubmitIdeeResponse(ideeEntities.Select(Idee.FromEntity)));
        }
        catch (BusinessLogicException ex)
        {
            return Ok(new SubmitIdeeResponse(ex.errors));
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.ToString());
            return Problem(ex.Message);
        }
    }

    // TODO Add another endpoint which retrieves all ideeen. This endpoint should have parameters to filter on idee type.
    // The view can call this on startup to display the existing ideeen.
}