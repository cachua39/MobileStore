using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MobileStore.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the MobileStoreUser class
    public class MobileStoreUser : IdentityUser
    {
        [PersonalData]
        public string FullName { get; set; }

        [PersonalData]
        public string Phone { get; set; }

        [PersonalData]
        public string Address { get; set; }
    }
}
