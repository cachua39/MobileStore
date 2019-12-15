using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MobileStore.Areas.Identity.Data;

namespace MobileStore.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<MobileStoreUser> _userManager;
        private readonly SignInManager<MobileStoreUser> _signInManager;

        public IndexModel(
            UserManager<MobileStoreUser> userManager,
            SignInManager<MobileStoreUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            // Custome User Info
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Full name")]
            public string FullName { get; set; }

            // Custome User Info
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Phone Number")]
            public string Phone { get; set; }

            // Custome User Info
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Address")]
            public string Address { get; set; }
        }

        private async Task LoadAsync(MobileStoreUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                //PhoneNumber = phoneNumber

                // Custom User Info
                FullName = user.FullName,
                Phone = user.Phone,
                Address = user.Address
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
                }
            }

            // Custom User Info
            if(Input.FullName != user.FullName)
            {
                user.FullName = Input.FullName;
            }

            // Custom User Info
            if(Input.Phone != user.Phone)
            {
                user.Phone = Input.Phone;
            }

            // Custom User Info
            if(Input.Address != user.Address)
            {
                user.Address = Input.Address;
            }

            // Update custom user info
            await _userManager.UpdateAsync(user);

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
