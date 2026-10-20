using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecapNewCore.Modules;
using RecapNewCore.Service;

namespace RecapNewCore.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class NumbersController:ControllerBase
{

    private readonly NumberService _numberService;

    public NumbersController(NumberService numberService)
    {
        _numberService = numberService;
    }

    
   [HttpPost("add")]
public async Task<IActionResult> AddNumbers(NumbersRequest request)
{
    var result = await _numberService.AddNumbers(request);

    return Ok(result);
}
    
    [HttpGet("view/{id}")]
    public IActionResult ViewAnswerById(int id)
    {
        var response = _numberService.ViewAnswerById(id);

        if (response == null)
        {
            return NotFound("Number with that ID was not found.");
        }

        return Ok(response);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteNumber(int id)
    {
        var result = await _numberService.DeleteNumber(id);

        if (!result)
        {
            return NotFound("id not found");
        }

        return Ok("deleted successfully");
    }

    [HttpPatch("update/{id}")]
    public async Task<IActionResult> EditNumber(int id, NumbersRequest request)
    {
        var number = await _numberService.EditNumber(id, request);
        if (number == null)
        {
            return NotFound("Number not found");
        }

        return Ok(number);
        
    }
    
    [HttpGet("viewall")]
    public async Task<ActionResult<List<NumbersResponse>>> ViewAllUsers()
    {
        var numbers = await _numberService.ViewAllNumbers();
        return Ok(numbers);
    }
    
}  
