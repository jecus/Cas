using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Abstractions
{
    public interface IIdentityUser : IBaseEntity
    {
        string Name { get; set; }
        string Surname { get; set; }
        string Login { get; set; }
        string Password { get; set; }
        UsetType UserType { get; set; }
    }
}
