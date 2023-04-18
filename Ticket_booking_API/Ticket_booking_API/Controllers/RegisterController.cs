using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
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

    public RegisterController(IUserRepositroy userRepositroy,IEmailSender emailSender,IMapper mapper)
    {
      _userRepository = userRepositroy;
      _emailSender = emailSender;
      _mapper = mapper;
    }
    [HttpPost("User")]
    public async Task<IActionResult> RegisterAsync([FromBody] UserDTO  userDTO)
     {
      if (ModelState.IsValid)
      {
        if (userDTO.Email != null)
        {
          await _emailSender.SendEmailAsync(userDTO.Email, "Booking Confirmation",
                              $"Your ticket is successfully bookes visit again ");
        }

        var user = _mapper.Map<UserDTO, User>(userDTO);

        var isUniqueUser = _userRepository.IsUniqueUser(user.Name);
        if (!isUniqueUser) return BadRequest("User In Use");

       // user.Password = _encryptionRepository.EncryptPassword(user.Password);

        var UserInfo = _userRepository.Register(userDTO);
        if (UserInfo == null) return BadRequest();
      }
      return Ok();
    }
    ////public static string HashPassword(string password)
    ////{
    ////  using (var sha256 = SHA256.Create())
    ////  {
    ////    var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
    ////    var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
    ////    return hash;
    ////  }

    }
  //  [HttpPost("authenticate")]

  //  public IActionResult Authenticate([FromBody] UserVM userVM)
  //  {
  //    var user = _userRepository.Authenticate(userVM.Email, HashPassword(userVM.PassWord));
  //    if (user == null) return BadRequest("Wrong User/Password");
  //    return Ok(user);
  //  }

  //}
}
