using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandevuTakip.Entities.Identity
{
    public class ApplicationUser:IdentityUser
    {
        public string UserGuidId { get; set; }
    }
}
