using apbd_05.service;
using Microsoft.AspNetCore.Mvc;

namespace apbd_05.controller;

[ApiController]
[Route("api/clients")]
public class ClientController(IClientService clientService, IClientTripService clientTripService) : ControllerBase
{
    [HttpDelete]
    [Route("{clientId}")]
    public async Task<IActionResult> DeleteClientWithId(int clientId)
    {
        if (await clientTripService.GetNumberOfTripsForClient(clientId) > 0)
        {
            return BadRequest("Client cannot be deleted with assigned trips");
        }
        int result = await clientService.DeleteClient(clientId);
        if (result == 0)
        {
            return BadRequest("Client with ID " + clientId + " not found");
        }
        return Ok("Client with ID " + clientId + " delted");
    }
}