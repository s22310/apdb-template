using Microsoft.AspNetCore.Mvc;
using WebAppTemplate.Properties.Services;

namespace WebAppTemplate.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TemplatesController : ControllerBase {
    //Dodaj serwis odpowiedialny za obsługę bazy danych
    private readonly ITemplatesService _templatesService;

    public TemplatesController(ITemplatesService templatesService) {
        _templatesService = templatesService;
    }

    //Dodawaj kolejne żądania
    [HttpGet]
    public async Task<IActionResult> GetTemplates() {
        var doctors = await _templatesService.GetTemplates();
        return Ok(doctors); // Zwróć uwagę na zwracane kody HTTP; dla żądań POST i PUT zwróć Created(URI, Object); dla błędów np. BadRequest()/NotFound();
    }

    //Pobieranie wartości z żądania
    /*
        [HttpDelete]
        [Route("{id:int}")]
     */
    //...
}