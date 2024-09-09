using HsptMS.Abstraction;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace HsptMS.Servises
{
    public class PasswordHasher: IPasswordHasher
    {
        private readonly IPasswordHasher _passwordHasher;
        public PasswordHasher(IPasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }
        public void Hash(string password,Guid salt,Guid peeper )
        {
            

         
        }

    }
}
