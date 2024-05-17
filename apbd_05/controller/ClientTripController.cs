using apbd_05.context;
using apbd_05.exception;
using apbd_05.models;
using apbd_05.service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace apbd_05.controller;

[ApiController]
[Route("api/trips")]
public class ClientTripController(IClientTripService clientTripService, IClientService clientService, Apbd05Context apbd05Context) : ControllerBase
{
    [HttpPost]
    [Route("{idTrip}/clients")]
    public async Task<IActionResult> AddClientToTrip(ClientTripDto clientTripDto)
    {
        try
        {
            clientTripService.ClientTripDtoIsNotValid(clientTripDto);
        }
        catch(IllegalClientTripArgumentException ex)
        {
            return BadRequest("Wrong data in request body: " + ex.Message);
        }
        int result = 0;
        using (IDbContextTransaction transaction = apbd05Context.Database.BeginTransaction())
        {
            Client client = await clientService.AddClient(clientTripDto);

            try
            {
                result = await clientTripService.AddClientToTrip(client, clientTripDto);
                transaction.Commit();
            }
            catch (IllegalClientTripArgumentException ex)
            {
                transaction.Rollback();
                return BadRequest(ex.Message);
            }
        }
        return result == 1 ? Ok("Client registered for trip") : BadRequest("Client not registered");
    }
}