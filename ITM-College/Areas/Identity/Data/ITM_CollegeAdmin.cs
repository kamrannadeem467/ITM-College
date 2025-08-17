using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ITM_College.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ITM_CollegeAdmin class
public class ITM_CollegeAdmin : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

