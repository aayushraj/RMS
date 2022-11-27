using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using RMS.Models;
using System.Text.Encodings.Web;
using System.Text;
using System.Net.Mail;
using RMSWeb.Models;
using LoginModel = RMSWeb.Models.LoginModel;
using RegisterModel = RMSWeb.Models.RegisterViewModel;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace RMSWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<LoginModel> _logger;
        
        //private readonly IEmailSender _emailSender;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<LoginModel> logger)//, IEmailSender emailSender)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            //_accountService = accountService;
            //_emailSender = emailSender;
        }
    
        public IActionResult Login()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {   

           // model.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
           // MailAddress address = new MailAddress(model.Email);
            // var UserName = address.User.ToString();

            if (ModelState.IsValid)
            {
                MailAddress address = new MailAddress(model.Email);
                var username = model.Email;
                if (address!=null)
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);
                    if (user != null)
                    {
                        username = user.UserName;
                    }
                }
                //this doesn't count login failures towards account lockout
                // to enable password failures to trigger account lockout, set lockoutonfailure: true
                var result = await _signInManager.PasswordSignInAsync(username, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("user logged in.");
                    return RedirectToAction("index", "dashboard");
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./loginwith2fa", new { rememberme = model.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("user account locked out.");
                    return RedirectToPage("./lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "invalid login attempt.");
                    return View();
                }

            }

            // If we got this far, something failed, redisplay form
            return View();
        }
        public  IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // MailAddress address = new MailAddress(model.Email);
                string userName = model.UserName;
                var checkUserNameExists = await _userManager.FindByNameAsync(userName);
                if(checkUserNameExists != null)
                {
                    ModelState.AddModelError(string.Empty, "UserName already Exists.");
                    return View();
                }
                var user = new ApplicationUser 
                { 
                    UserName = userName,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email 
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code},
                        protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(model.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = model.Email});
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Login");
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return View();
        }
        public async Task<IActionResult> LogOut(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return View();
            }
            
        }
        public async Task<IActionResult> ManageUser()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            ManageUserModel model = new ManageUserModel();
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.UserName = await _userManager.GetUserNameAsync(user);
            model.PhoneNumber = await _userManager.GetPhoneNumberAsync(user);
            model.ProfilePicture = user.ProfilePicture;
            model.StatusMessage = null;
            //await LoadAsync(user);
            //return Page();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ManageUser(ManageUserModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            var firstName = user.FirstName;
            var lastName = user.LastName;
            if (model.FirstName != firstName)
            {
                user.FirstName = model.FirstName;
                await _userManager.UpdateAsync(user);
            }
            if (model.LastName != lastName)
            {
                user.LastName = model.LastName;
                await _userManager.UpdateAsync(user);
            }

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            if (user.UserNameChangeLimit > 0)
            {
                if (model.UserName != user.UserName)
                {
                    var userNameExists = await _userManager.FindByNameAsync(model.UserName);
                    if (userNameExists != null)
                    {
                        model.StatusMessage = "User name already taken. Select a different username.";
                        return View(model);
                    }
                    var setUserName = await _userManager.SetUserNameAsync(user, model.UserName);
                    if (!setUserName.Succeeded)
                    {
                        model.StatusMessage = "Unexpected error when trying to set user name.";
                        return View(model);
                    }
                    else
                    {
                        user.UserNameChangeLimit -= 1;
                        await _userManager.UpdateAsync(user);
                    }
                }
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (model.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, model.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                   model.StatusMessage = "Unexpected error when trying to set phone number.";
                    return View(model);
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            model.StatusMessage = "Your profile has been updated";
            return View(model);
        }
    }
}
