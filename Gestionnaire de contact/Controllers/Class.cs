using CarnetAdresseApi.Models;
using CarnetAdresseApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarnetAdresseApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PeopleController : ControllerBase
{
    private readonly PeopleService _peopleService;

    public PeopleController(PeopleService peopleService) =>
        _peopleService = peopleService;

    [HttpGet]
    public async Task<List<Person>> Get() =>
        await _peopleService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Person>> Get(string id)
    {
        var person = await _peopleService.GetAsync(id);

        if (person is null)
        {
            return NotFound();
        }

        return person;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Person newPerson)
    {
        await _peopleService.CreateAsync(newPerson);

        return CreatedAtAction(nameof(Get), new { id = newPerson.Id }, newPerson);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Person updatedPerson)
    {
        var person = await _peopleService.GetAsync(id);

        if (person is null)
        {
            return NotFound();
        }

        updatedPerson.Id = person.Id;

        await _peopleService.UpdateAsync(id, updatedPerson);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var person = await _peopleService.GetAsync(id);

        if (person is null)
        {
            return NotFound();
        }

        await _peopleService.RemoveAsync(id);

        return NoContent();
    }
}