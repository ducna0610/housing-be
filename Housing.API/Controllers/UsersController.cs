using Housing.API.Controllers.Common.Wrapper;
using Housing.Application.DTOs.Requests;
using Housing.Application.DTOs.Responses;
using Housing.Application.Interfaces;
using Housing.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Housing.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUnitOfWork _uow;
    private readonly IConfiguration _configuration;

    public UsersController(IUnitOfWork uow, IConfiguration configuration)
    {
        _configuration = configuration;
        _uow = uow;
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Login(LoginRequest req)
    {
        var user = await _uow.UserRepository.Authenticate(req.UserName, req.Password);

        ApiError apiError = new ApiError();

        if (user == null)
        {
            apiError.ErrorCode = Unauthorized().StatusCode;
            apiError.ErrorMessage = "Invalid user name or password";
            apiError.ErrorDetails = "This error appear when provided user id or password does not exists";
            return Unauthorized(apiError);
        }

        var res = new TokenResponse();
        res.Token = CreateJWT(user);
        return Ok(res);
    }

    [HttpPost("register")]
    [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Register(LoginRequest loginReq)
    {
        ApiError apiError = new ApiError();

        if (await _uow.UserRepository.UserAlreadyExists(loginReq.UserName))
        {
            apiError.ErrorCode = BadRequest().StatusCode;
            apiError.ErrorMessage = "User already exists, please try different user name";
            return BadRequest(apiError);
        }

        _uow.UserRepository.Register(loginReq.UserName, loginReq.Password);
        await _uow.SaveAsync();
        return StatusCode(StatusCodes.Status201Created);
    }

    private string CreateJWT(User user)
    {
        var secretKey = _configuration.GetSection("AppSettings:Key").Value;
        var key = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(secretKey));

        var claims = new Claim[] {
            new Claim(ClaimTypes.Name,user.Username),
            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };

        var signingCredentials = new SigningCredentials(
                key, SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(1),
            SigningCredentials = signingCredentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
