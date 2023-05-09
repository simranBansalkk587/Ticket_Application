using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Ticket_booking_API.Data;
using Ticket_booking_API.DTO;
using Ticket_booking_API.Models;
using Ticket_booking_API.Repository.IRepository;

namespace Ticket_booking_API.Repository
{
  public class UserRepository : IUserRepositroy
  {
    private readonly ApplicationDbContext _context;
    private readonly AppSettings _appSettings;

    public UserRepository(ApplicationDbContext context, IOptions<AppSettings> appSettings)
    {
      _context = context;
      _appSettings = appSettings.Value;
    }
    public User Authenticate(string username, string password)

    {
      var userInDb = _context.Users.FirstOrDefault(u => u.Email == username && u.Password == password);
      if (userInDb == null) return null;
      //jwt
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
      var tokenDescritor = new SecurityTokenDescriptor()
      {
        Subject = new ClaimsIdentity(new Claim[]
          {
                    new Claim(ClaimTypes.Name, userInDb.Id.ToString()),
                    new Claim(ClaimTypes.Role,userInDb.Role)
          }),
        Expires = DateTime.UtcNow.AddDays(7),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
          SecurityAlgorithms.HmacSha256Signature)

      };
      var token = tokenHandler.CreateToken(tokenDescritor);
      userInDb.Token = tokenHandler.WriteToken(token);
      userInDb.Password = "";
      return userInDb;

    }
    public bool IsUniqueUser(string UserName)
    {
      var User = _context.Users.FirstOrDefault(r => r.Name == UserName);
      if (User == null)
        return true;
      else
        return false;
    }

   

    public User Register(UserDTO userDTO)
    {
      User user = new User()
      {
        Name = userDTO.Name,
        Address = userDTO.Address,
        Email = userDTO.Email,
       Password = HashPassword(userDTO.Password),
        RegistrationDate = userDTO.RegistrationDate,
        ExprieDate = userDTO.ExprieDate,
        Role = "User"
      };
      _context.Users.Add(user);
      _context.SaveChanges();
      return user;
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

    public User setPassword(UserDTO userDTO)
    {
      var userInDb = _context.Users.FirstOrDefault(u => u.Id == userDTO.Id);
      if(userInDb !=null)
      {
        userInDb.Password = HashPassword(userDTO.Password);
      }
      _context.Users.Update(userInDb);
      _context.SaveChanges();
      return userInDb;
    }
  }
}

 

