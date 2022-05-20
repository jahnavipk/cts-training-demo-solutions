using ECommerce.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Interfaces
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(Users user);
    }
}
