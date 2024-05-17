using apbd_05.service;
using Microsoft.AspNetCore.Mvc;

namespace apbd_05.controller;

[ApiController]
[Route("api/trips")]
public class TripController(ITripService _tripService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllTrips()
    {
        return Ok(await _tripService.GetAllTrips());
    }
}