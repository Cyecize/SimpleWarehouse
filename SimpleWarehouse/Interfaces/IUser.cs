using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimpleWarehouse.Interfaces
{
    public interface IUser
    {

        int Id { get; set; }

        string Username { get; set; }

        string Password { get; set; }

        string Role { get; set; }

        DateTime DateRegistered { get; set; }

        bool IsActive { get; set; }
    }
}
