using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using Trifoia.Module.LottiePlayer.Repository;
using Oqtane.Controllers;
using System.Net;
using System.Threading.Tasks;
using System;

namespace Trifoia.Module.LottiePlayer.Controllers;

[Route(ControllerRoutes.ApiRoute)]
public class LottiePlayerController : ModuleControllerBase
{
    private readonly LottiePlayerRepository _LottiePlayerRepository;

    public LottiePlayerController(LottiePlayerRepository LottiePlayerRepository, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor)
    {
        _LottiePlayerRepository = LottiePlayerRepository;
    }

    // GET: api/<controller>?moduleid=x
    [HttpGet]
    [Authorize(Roles = RoleNames.Registered)]
    public async Task<ActionResult<IEnumerable<Models.LottiePlayer>>> Get(){
        try{
            var data = _LottiePlayerRepository.GetLottiePlayers();
            return Ok(data);
        }
        catch(Exception ex){
            var errorMessage = $"Repository Error Get Attempt LottiePlayer";
            _logger.Log(LogLevel.Error, this, LogFunction.Read, errorMessage);
            return StatusCode(500);
        }
    }

    // GET api/<controller>/5
    [HttpGet("{id}")]
    [Authorize(Roles = RoleNames.Registered)]
    public async Task<ActionResult<Models.LottiePlayer>> Get(int id)
    {
        try {
            var data = _LottiePlayerRepository.GetLottiePlayer(id);
            return Ok(data);
        }
        catch (Exception ex)       { 
            _logger.Log(LogLevel.Error, this, LogFunction.Read, "Failed LottiePlayer Get Attempt {id}", id);
            return StatusCode(500);
        }
    }

    // POST api/<controller>
    [HttpPost]
    [Authorize(Roles = RoleNames.Registered)]
    public async Task<ActionResult<Models.LottiePlayer>> Post([FromBody] Models.LottiePlayer item)
    {
        if (ModelState.IsValid)
        {
            try{
                item = _LottiePlayerRepository.AddLottiePlayer(item);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "LottiePlayer Added {LottiePlayer}", item);
            }
            catch (Exception ex) {
                _logger.Log(LogLevel.Error, this, LogFunction.Read, "Failed LottiePlayer Add Attempt {item} Message {Message} ", item, ex.Message);
                return StatusCode(500);
            }
        }
        else
        {
            _logger.Log(LogLevel.Error, this, LogFunction.Create, "Invaid LottiePlayer Post Attempt {item}", item);
            return BadRequest();
        }
        return Ok(item);
    }

    // PUT api/<controller>/5
    [HttpPut("{id}")]
    [Authorize(Roles = RoleNames.Registered)]
    public async Task<ActionResult<Models.LottiePlayer>> Put(int id, [FromBody] Models.LottiePlayer item)
    {
        if (ModelState.IsValid && _LottiePlayerRepository.GetLottiePlayer(item.LottiePlayerId, false) != null)
        {
            item = _LottiePlayerRepository.UpdateLottiePlayer(item);
            _logger.Log(LogLevel.Information, this, LogFunction.Update, "LottiePlayer Updated {item}", item);
            return Ok(item);
        }
        else
        {
            _logger.Log(LogLevel.Error, this, LogFunction.Update, "Unauthorized LottiePlayer Put Attempt {item}", item);
            return BadRequest();
        }
    }

    // DELETE api/<controller>/5
    [HttpDelete("{id}")]
    [Authorize(Roles = RoleNames.Registered)]
    public async Task<ActionResult> Delete(int id)
    {
        var data = _LottiePlayerRepository.GetLottiePlayer(id);
        if (data is null)
        {
            _logger.Log(LogLevel.Error, this, LogFunction.Delete, "Failed LottiePlayer Delete Attempt {LottiePlayerId}", id);
            return NotFound();
        }

        _LottiePlayerRepository.DeleteLottiePlayer(id);
        _logger.Log(LogLevel.Information, this, LogFunction.Delete, "LottiePlayer Deleted {LottiePlayerId}", id);
        return Ok();
    
    }
}