using FastTechFoods.APIGateway.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FastTechFoods.APIGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IConfiguration configuration, ILogger<AuthController> logger)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost("login/employee")]
        public IActionResult Login([FromBody] EmployeeLoginRequest request)
        {
            if (request is null || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("Invalid login request.");
            }

            // --- 1. Validate Employee Credentials (Mocked for example) ---
            if (request.Email == "employee@fasttech.com" && request.Password == "password123")
            {
                // --- 2. Generate JWT Token for Employee ---
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, "emp123"), // Employee ID
                    new Claim(ClaimTypes.Email, request.Email),
                    new Claim(ClaimTypes.Role, "Employee"), // Assign Employee role
                };

                var token = GenerateJwtToken(claims);
                _logger.LogInformation("Employee {Email} logged in successfully.", request.Email);
                return Ok(new { Token = token, UserType = "Employee" });
            }

            _logger.LogWarning("Employee login failed for {Email}.", request.Email);
            return Unauthorized("Invalid credentials.");
        }

        private string GenerateJwtToken(Claim[] claims)
        {
            var jwtIssuer = _configuration["Jwt:Issuer"];
            var jwtAudience = _configuration["Jwt:Audience"];
            var jwtKey = _configuration["Jwt:Key"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtIssuer,
                audience: jwtAudience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
