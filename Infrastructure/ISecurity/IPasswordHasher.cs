using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ISecurity
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool VerifyPasswordB(string password, string hashedPassword);
    }
}
