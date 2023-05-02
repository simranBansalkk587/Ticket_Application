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
        if (userDTO.Email != null)
        {
          await _emailSender.SendEmailAsync(userDTO.Email, "Booking Confirmation",
                              $"Your ticket is successfully bookes visit again ",userDTO.Id);
        }

        var user = _mapper.Map<UserDTO, User>(userDTO);

        var isUniqueUser = _userRepository.IsUniqueUser(user.Name);
        if (!isUniqueUser) return BadRequest("User In Use");


        //  user.Password = _encryptionRepository.EncryptPassword(user.Password);

        var UserInfo = _userRepository.Register(userDTO);
        if (UserInfo == null) return BadRequest();
      }
      return Ok();
    }
    //[HttpPost("User")]
    //public async Task<IActionResult> RegisterUser([FromBody] User user)
    //{
    //  try
    //  {
    //    if (ModelState.IsValid)
    //    {
    //      if (user.Email != null)
    //      {




    //        var hashedPassword = HashPassword(user.Password);  //for password hashing
    //        user.Password = hashedPassword;


    //        var token = Guid.NewGuid().ToString();  // for generating email confirmation
    //        user.EmailConfirmedToken = token;


    //        await _context.Users.AddAsync(user);
    //        await _context.SaveChangesAsync();

    //        var subject = "Confirm your email address";
    //        var callBackurl = Url.Action("ConfirmEmail", "User", new { userid = user.Id, token }, protocol: HttpContext.Request.Scheme);
    //        var message = $"Please confirm your email address by clicking this link: <a href='{callBackurl}'>Click Me </a>";

    //        await _emailSender.SendEmailAsync(user.Email, subject, message);

    //        return Ok();

    //      }
    //    }
    //  }

    //  catch (Exception)
    //  {

    //    throw;
    //  }
    //  return BadRequest();

    //}


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


    //[HttpGet("confirm-email")]
    //public async Task<IActionResult> ConfirmEmail(int userId, string token)
    //{

    //  var user = await _context.Users.FindAsync(userId);

    //  if (user == null)
    //  {
    //    return NotFound();
    //  }

    //  if (user.EmailConfirmedToken != token)
    //  {
    //    return BadRequest("Invalid token");
    //  }

    //  user.EmailConfrimed = true;


    //  await _context.SaveChangesAsync();



    //  return Redirect("http://localhost:4200/login");

    //}
  }
}









