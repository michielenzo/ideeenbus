using Microsoft.AspNetCore.Mvc;
using ideeenbus.Models;
using ideeenbus.Service;
using ideeenbus.Service.Dao;
using Microsoft.EntityFrameworkCore;
using ideeenbus.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using ideeenbus.Controllers.Dto;


namespace ideeenbus.Controllers;

[ApiController]
[Route("IdeeenController/")]
public class IdeeenController: ControllerBase {

    // Todo use dependency injection.
    private IdeeEntityContext _context = new IdeeEntityContext();

    [HttpPost]
    [Route("SubmitForm")]
    public async Task<IActionResult> SubmitForm([FromForm] Idee idee)
    {
        try
        {
            idee.Validate();
            
            _context.Add(IdeeEntity.fromModel(idee));
            await _context.SaveChangesAsync();

            List<IdeeEntity> ideeEntities = await _context.Ideeen.ToListAsync();
            return Ok(new Response([null], true, ideeEntities.Select(Idee.FromEntity)));
        }
        catch (BusinessLogicException ex) 
        {
            return Ok(new Response(ex.errors, false, null));
        } 
        catch (Exception ex) 
        {
            return Problem(ex.Message);
        }
    }
}