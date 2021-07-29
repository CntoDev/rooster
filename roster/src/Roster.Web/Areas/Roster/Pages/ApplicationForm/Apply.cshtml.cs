using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Roster.Core.Services;
using Roster.Core.Commands;
using System.Collections.Generic;
using Roster.Core.Domain;
using Roster.Web.Utilities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Roster.Web.Areas.Roster.Pages.ApplicationForm
{
    [AllowAnonymous]
    public class ApplyModel : PageModel
    {
        private string[] _dlcNames = { "Karts", "Helicopters", "Marksmen", "Apex", "Jets", "Malden", "Laws of War", "Tac-Ops", "Tanks", "Contact", "Art of War", "CSLA: Iron Curtain", "Global Mobilization", "S.O.G. Prairie Fire" };
        private readonly ApplicationService _rosterCoreService;
        private readonly ILogger<ApplyModel> _logger;
        private ICollection<Arma3Dlc> _ownedDlcs;

        public ApplyModel(ApplicationService rosterCoreService, ILogger<ApplyModel> logger)
        {
            _rosterCoreService = rosterCoreService;
            _logger = logger;
            _ownedDlcs = new List<Arma3Dlc>();

            Dlcs = _dlcNames.Select(x => new SelectListItem(x, x)).ToList();
        }

        [Required]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [BindProperty]
        public string Email { get; set; }

        [Required]
        [BindProperty]
        public string Nickname { get; set; }

        [Required]
        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        [BindProperty]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Bohemia Interactive nickname")]
        [BindProperty]
        public string BiNickname { get; set; }

        [Display(Name = "Discord ID")]
        [BindProperty]
        public string DiscordId { get; set; }

        [Display(Name = "GitHub nickname")]
        [BindProperty]
        public string GithubNickname { get; set; }

        [Display(Name = "Google e-mail")]
        [DataType(DataType.EmailAddress)]
        [BindProperty]
        public string Gmail { get; set; }

        [Display(Name = "Steam username")]
        [BindProperty]
        public string SteamId { get; set; }

        [Display(Name = "Teamspeak ID")]
        [BindProperty]
        public string TeamspeakId { get; set; }

        [Display(Name = "Owned DLCs")]
        [BindProperty]
        public IEnumerable<string> OwnedDlcs
        {
            get
            {
                return _ownedDlcs.Select(dlc => dlc.Name);
            }
            set
            {
                _ownedDlcs = value.Select(x => new Arma3Dlc() { Name = x })
                                  .ToList();
            }
        }

        public List<SelectListItem> Dlcs { get; set; }

        public IActionResult OnGet()
        {
            DateOfBirth = DateTime.Now.Date;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                ApplicationFormCommand formCommand = new ApplicationFormCommand(Nickname, DateOfBirth, Email)
                {
                    BiNickname = BiNickname,
                    DiscordId = DiscordId,
                    GithubNickname = GithubNickname,
                    Gmail = Gmail,
                    OwnedDlcs = _ownedDlcs,
                    SteamId = SteamId,
                    TeamspeakId = TeamspeakId
                };
                _logger.LogInformation("Submitting application form {@command}", formCommand);
                var result = _rosterCoreService.SubmitApplicationForm(formCommand);
                if (result.IsSuccess)
                {
                    _logger.LogInformation("Application form success.");
                    return RedirectToPage("ApplicationFormCreated", new { nickname = Nickname });
                }
                else
                {
                    _logger.LogError("Application form submit failed with error {errors}", result.ToString());
                    ModelState.AddResultErrors(result);
                }

            }

            return Page();
        }
    }
}