using apbd_05.models;
using apbd_05.service;
using Microsoft.AspNetCore.Mvc;

namespace apbd_05.controller;

[ApiController]
[Route("api/trips")]
public class ClientTripController(IClientTripService clientTripService, IClientService clientService) : ControllerBase
{
    [HttpPost]
    [Route("{idTrip}/clients")]
    public async Task<IActionResult> AddClientToTrip(ClientTripDto clientTripDto)
    {
        Client client = await clientService.AddClient(clientTripDto);
        //await clientTripService.AddClientToTrip(clientTripDto);
        return Ok(client);
    }
}