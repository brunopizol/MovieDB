using AutoMapper;
using GreenDonut;
using Microsoft.AspNetCore.Mvc;
using MovieDB.Application.Dtos;
using MovieDB.Application.Services;
using MovieDB.Domain.Entities;


namespace MovieDB.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserService _userService;
        private readonly AuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public UserController(ILogger<UserController> logger,
            UserService userService, 
            AuthenticationService authenticationService,
            IMapper mapper)
        {
            _logger = logger;
            _userService = userService;
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        [HttpPost("registrar")]
        public ActionResult RegisterUser([FromBody] UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            _userService.RegisterUser(user);
            return new OkObjectResult(new { Status = 200, Mensagem = "Jogador registrado com sucesso" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDto model, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.Handle(model, cancellationToken);

            if (result.Status == "Success")
            {
                return new OkObjectResult(new { token = result.Token });
            }
            else
            {
                return new UnauthorizedObjectResult(new { error = result.Message });
            }
        }
    }
}
