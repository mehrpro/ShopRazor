using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ShopRazor.Areas.Identity.Pages.Account.Manage
{
    public class Disable2faModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<Disable2faModel> _logger;

        public Disable2faModel(
            UserManager<IdentityUser> userManager,
            ILogger<Disable2faModel> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"بارگیری کاربر با شناسه ممکن نیست '{_userManager.GetUserId(User)}'.");
            }

            if (!await _userManager.GetTwoFactorEnabledAsync(user))
            {
                throw new InvalidOperationException($"نمی توان 2FA را برای کاربر با شناسه غیرفعال کرد '{_userManager.GetUserId(User)}' چون در حال حاضر فعال نیست");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"بارگیری کاربر با شناسه ممکن نیست '{_userManager.GetUserId(User)}'.");
            }

            var disable2faResult = await _userManager.SetTwoFactorEnabledAsync(user, false);
            if (!disable2faResult.Succeeded)
            {
                throw new InvalidOperationException($"هنگام غیرفعال کردن 2FA برای کاربر دارای شناسه، خطای غیرمنتظره‌ای روی داد '{_userManager.GetUserId(User)}'.");
            }

            _logger.LogInformation("کاربر با شناسه {UserId} 2fa را غیرفعال کرده است.", _userManager.GetUserId(User));
            StatusMessage = "2fa غیر فعال شده است. هنگامی که یک برنامه احراز هویت را راه اندازی می کنید، می توانید 2fa را دوباره فعال کنید";
            return RedirectToPage("./TwoFactorAuthentication");
        }
    }
}