using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Ticket_booking_API.Data;
using Ticket_booking_API.DTO;
using Ticket_booking_API.Models;
using Ticket_booking_API.Repository.IRepository;

namespace Ticket_booking_API.Controllers
{
  [Route("api/Register")]
  [ApiController]
  public class RegisterController : ControllerBase
  {
    private readonly IUserRepositroy _userRepository;
    private readonly IEmailSender _emailSender;
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public RegisterController(IUserRepositroy userRepositroy, IEmailSender emailSender, IMapper mapper, ApplicationDbContext context)
    {
      _userRepository = userRepositroy;
      _emailSender = emailSender;
      _mapper = mapper;
      _context = context;
    }
    [HttpPost("User")]
    public async Task<IActionResult> RegisterAsync([FromBody] UserDTO userDTO)

    {
      if (ModelState.IsValid)
      {
        var user = _mapper.Map<UserDTO, User>(userDTO);
        var UserName = _userRepository.IsUniqueUser(user.Name);
        if (!UserName) return BadRequest("User In Use");
        userDTO.Password = HashPassword(userDTO.Password);
        var userInDb = _userRepository.Register(userDTO);
          if (userInDb == null) return BadRequest();
          if(userInDb.Email !=null && userInDb.Id !=0)
        {
          var setpassword = $"http://localhost:4200/password?id={userInDb.Id}";
          await _emailSender.SendEmailAsync(userDTO.Email, "Set Your Password", $"Please click on this link set password:{ setpassword}");
        }
       
      }
      return Ok();
    }
   


    [HttpPost("authenticate")]

    public IActionResult Authenticate([FromBody] UserVM userVM)
    {
      var user = _userRepository.Authenticate(userVM.Email, HashPassword(userVM.PassWord));

      if (user == null) return BadRequest("Wrong User/Password");
      return Ok(user);
    }
    public static string HashPassword(string password)
    {
      using (var sha256 = SHA256.Create())
      {
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        return hash;
      }

    }
    [HttpPut("Update")]
    public IActionResult SetPassWord([FromBody]UserDTO userDTO)
    {
      if(userDTO==null)
      {
        return BadRequest(ModelState);

      }
      _userRepository.setPassword(userDTO);
      return Ok();
    }
    
  }
}









