using Microsoft.AspNetCore.Identity;
using ORRAS.Application.Common.Interfaces;

namespace ORRAS.Infrastructure.Identity
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public string JobTitle { get; set; }

    }
}