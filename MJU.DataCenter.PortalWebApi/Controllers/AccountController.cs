using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MJU.DataCenter.PortalWebApi.Models;
using MJU.DataCenter.PortalWebApi.Services;
using MJU.DataCenter.PortalWebApi.Services.Interface;
using MJU.DataCenter.PortalWebApi.ViewModels;

namespace MJU.DataCenter.PortalWebApi.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        //  private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;

        private readonly IUserDepartmentRoleService _userDepartmentService;

        public AccountController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            //  IEmailSender emailSender,
            // 
            ILogger<AccountController> logger,
            IUserDepartmentRoleService userDepartmentService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            //  _emailSender = emailSender;
            _logger = logger;
            _userDepartmentService = userDepartmentService;

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true

                var user = await _userManager.FindByNameAsync(model.Email);
                var checkRole = await _userManager.IsInRoleAsync(user, "User");
                if (checkRole)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }

                var claims = _userManager.GetClaimsAsync(user);

                if (!claims.Result.Any(x => x.Type == "DCApiToken"))
                    _userManager.AddClaimAsync(user, new Claim("DCApiToken", user.AccessToken.ToString())).Wait();
                if (!claims.Result.Any(x => x.Type == "UserId"))
                    _userManager.AddClaimAsync(user, new Claim("UserId", user.Id.ToString())).Wait();

                _userManager.UpdateAsync(user).Wait();

                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");

                    var roles = await _userManager.GetRolesAsync(user);

                    _userManager.AddToRolesAsync(user, roles).Wait();

                    return RedirectToLocal(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    //  return RedirectToAction(nameof(LoginWith2fa), new { returnUrl, model.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    //  _logger.LogWarning("User account locked out.");
                    // return RedirectToAction(nameof(Lockout));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticated(string userName, string password, string token)
        {
            var model = new LoginApiModel
            {
                IsSuccess = false
            };

            if (token == null) return BadRequest(new LoginApiModel
            {
                IsSuccess = false,
                Description = "Token is not valid"
            });

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
            var result = await _signInManager.PasswordSignInAsync(userName, password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                _logger.LogInformation("User logged in.");
                var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    if (Guid.Parse(token) == user.AccessToken)
                    {
                        var data = _userDepartmentService.GetById(user.Id);
                        //find user role with token
                        model = new LoginApiModel
                        {
                            IsSuccess = true,
                            AccessToken = token,
                            DepartmentRoleList = data.Select(x => x.DepartmentRole).ToList()
                        };
                        return Ok(model);
                    }
                }
            }
            return BadRequest(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AuthenticatedToken(string token)
        {
            var model = new LoginApiModel
            {
                IsSuccess = false
            };

            if (token == null) return BadRequest(new LoginApiModel
            {
                IsSuccess = false,
                Description = "Token is not valid"
            });

            var userDepartmentRole = _userDepartmentService.GetDepartmentRoleByToken(Guid.Parse(token));
            if (userDepartmentRole.Any())
            {
                model = new LoginApiModel
                {
                    IsSuccess = true,
                    AccessToken = token,
                    DepartmentRoleList = userDepartmentRole.Select(x => x.DepartmentRole).ToList()
                };
                return Ok(model);
            }
            return BadRequest(model);
        }

        //[HttpGet]
        //[AllowAnonymous]
        //public async Task<IActionResult> LoginWith2fa(bool rememberMe, string returnUrl = null)
        //{
        //    // Ensure the user has gone through the username & password screen first
        //    var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();

        //    if (user == null)
        //    {
        //        throw new ApplicationException($"Unable to load two-factor authentication user.");
        //    }

        //    var model = new LoginWith2faViewModel { RememberMe = rememberMe };
        //    ViewData["ReturnUrl"] = returnUrl;

        //    return View(model);
        //}

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> LoginWith2fa(LoginWith2faViewModel model, bool rememberMe, string returnUrl = null)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
        //    if (user == null)
        //    {
        //        throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        //    }

        //    var authenticatorCode = model.TwoFactorCode.Replace(" ", string.Empty).Replace("-", string.Empty);

        //    var result = await _signInManager.TwoFactorAuthenticatorSignInAsync(authenticatorCode, rememberMe, model.RememberMachine);

        //    if (result.Succeeded)
        //    {
        //        _logger.LogInformation("User with ID {UserId} logged in with 2fa.", user.Id);
        //        return RedirectToLocal(returnUrl);
        //    }
        //    else if (result.IsLockedOut)
        //    {
        //        _logger.LogWarning("User with ID {UserId} account locked out.", user.Id);
        //        return RedirectToAction(nameof(Lockout));
        //    }
        //    else
        //    {
        //        _logger.LogWarning("Invalid authenticator code entered for user with ID {UserId}.", user.Id);
        //        ModelState.AddModelError(string.Empty, "Invalid authenticator code.");
        //        return View();
        //    }
        //}


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new AppUser { UserName = model.Email, Email = model.Email, AccessToken = Guid.NewGuid() };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    // var callbackUrl = Url.EmailConfirmationLink(user.Id.ToString(), code, Request.Scheme);
                    //await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

                    var claims = _userManager.GetClaimsAsync(user);

                    if (!claims.Result.Any(x => x.Type == "DCApiToken"))
                        _userManager.AddClaimAsync(user, new Claim("DCApiToken", user.AccessToken.ToString())).Wait();
                    if (!claims.Result.Any(x => x.Type == "UserId"))
                        _userManager.AddClaimAsync(user, new Claim("UserId", user.Id.ToString())).Wait();

                    _userManager.UpdateAsync(user).Wait();

                    _userManager.AddToRoleAsync(user, "Developer").Wait();

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation("User created a new account with password.");
  
                    return RedirectToLocal(returnUrl);
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpPost]
        public DepartmentRole UpdateDepartmentRole(int departmentRoleId, string departmentRoleName, string departmentRoleNameTH, string departmentKey, Guid? departmentApiToken)
        {

            return _userDepartmentService.UpdateDepartmentRole(departmentRoleId, departmentRoleName, departmentRoleNameTH, departmentKey, departmentApiToken);
        }

        [HttpPost]
        public DepartmentRole AddDepartmentRole(string departmentRoleName, string departmentRoleNameTH, string departmentKey, Guid? departmentApiToken)
        {

            return _userDepartmentService.AddDepartmentRole(departmentRoleName, departmentRoleNameTH, departmentKey, departmentApiToken);
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        #endregion
    }
}