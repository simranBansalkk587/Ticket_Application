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

namespace Ticket_booking_API.Repository
{
  public class UserRepository : IUserRepositroy
  {
    private readonly ApplicationDbContext _context;
    public UserRepository(ApplicationDbContext context)
    {
      _context = context;
    }
    public User Authenticate(string UserName, string password)
    {
      throw new NotImplementedException();
    }

    public bool IsUniqueUser(string UserName)
    {
      var User = _context.Users.FirstOrDefault(r => r.Name == UserName);
      if (User == null)
        return true;
      else
        return false;
    }

    ////public User Register(string UserName, string UserPassword)
    ////{
    ////  User user = new User()
    ////  {
    ////    Name = UserName,
    ////    Password = UserPassword

    ////  };

    ////  _context.Users.Add(user);
    ////  _context.SaveChanges();
    ////  return user;
    ////}

    public User Register(UserDTO userDTO)
    {
      User user = new User()
      {
        Name = userDTO.Name,
        Address = userDTO.Address,
        Email = userDTO.Email,
        //  Password =userDTO.Password,
        RegistrationDate = userDTO.RegistrationDate,
        ExprieDate = userDTO.ExprieDate,
        Role="Admin"
      };
      _context.Users.Add(user);
      _context.SaveChanges();
      return user;
    }
    //public static string HashPassword(string password)
    //{
    //  using (var sha256 = SHA256.Create())
    //  {
    //    var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
    //    var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
    //    return hash;
    //  }

    }
  }

 

