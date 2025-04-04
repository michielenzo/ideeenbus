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

    // Todo use dependency injection i.c.m adapter pattern voor data opslag.
    private DatabaseContext _context = new DatabaseContext();

    [HttpPost]
    [Route("SubmitForm")]
    public async Task<IActionResult> SubmitForm([FromForm] Idee idee)
    {
        //return Ok("hallo");
        try
        {
            idee.Validate();

            _context.Add(IdeeEntity.fromModel(idee));
            await _context.SaveChangesAsync();

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
            Console.WriteLine(ex.ToString());
            return Problem(ex.Message);
        }
    }
}