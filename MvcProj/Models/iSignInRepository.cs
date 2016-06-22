using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProj.Models
{
    public interface ISignInRepository
    {
        bool verifier(User u);
        bool saveSignUp(User u);

    }
}
