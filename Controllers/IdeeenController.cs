using Microsoft.AspNetCore.Mvc;
using ideeenbus.Models;
using ideeenbus.Exceptions;
using ideeenbus.Controllers.Dto;
using ideeenbus.Service;


namespace ideeenbus.Controllers;

[ApiController]
[Route("IdeeenController/")]
public class IdeeenController(IIdeeenService ideeenService) : ControllerBase {

    private readonly IIdeeenService _ideeenService = ideeenService;

    [HttpPost("SubmitForm")]
    public async Task<IActionResult> SubmitForm([FromForm] Idee idee)
    {
        try
        {
            idee.Validate();

            await _ideeenService.PersistAsync(idee);

            List<Idee> ideeen = await _ideeenService.FetchAllAsync();

            return Ok(new SubmitIdeeResponse(ideeen));
        }
        catch (BusinessLogicException ex)
        {
            return UnprocessableEntity(new SubmitIdeeResponse(ex.errors));
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.ToString());
            return Problem("Internal server error. Something went wrong.");
        }
    }

    // TODO Add another endpoint which retrieves all ideeen. This endpoint should have parameters to filter on idee type.
    // The view can call this on startup or on filter request.
}