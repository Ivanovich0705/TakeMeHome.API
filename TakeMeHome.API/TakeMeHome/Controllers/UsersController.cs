using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TakeMeHome.API.Shared.Extensions;
using TakeMeHome.API.TakeMeHome.Domain.Models;
using TakeMeHome.API.TakeMeHome.Domain.Services;
using TakeMeHome.API.TakeMeHome.Resources;

namespace TakeMeHome.API.TakeMeHome.Controllers;

[Route("/api/v1/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UsersController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<UserResource>> GetAllAsync()
    {
        var users = await _userService.ListAsync();
        var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveUserResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var user = _mapper.Map<SaveUserResource, User>(resource);
        var result = await _userService.SaveAsync(user);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var userResource = _mapper.Map<User, UserResource>(result.Resource);
        return Ok(userResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _userService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var userResource = _mapper.Map<User, UserResource>(result.Resource);
        return Ok(userResource);
    }
    
    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] JsonPatchDocument<User> resource)
    {
        var user = await _userService.FindByIdAsync(id);
        
        if (user == null)
        {
            return NotFound();
        }
        
        resource.ApplyTo(user);
        
        
        var result = await _userService.UpdateAsync(id, user);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var userResource = _mapper.Map<User, UserResource>(result.Resource);
        return Ok(user);
    }


}