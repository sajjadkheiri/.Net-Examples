using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Net_Example.Identity;

public class List : PageModel
{
    private readonly UserManager<IdentityUser> _userManager;
    public IEnumerable<IdentityUser> Users { get; set; } = new List<IdentityUser>();
    
    public List(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;   
    }
    
    public void OnGet()
    {
        Users = _userManager.Users.ToList();
    }
}