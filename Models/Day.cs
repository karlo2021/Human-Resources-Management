using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityApp.Models;

public class Day
{
    public long Id { get; set; }
    public int Name { get; set; }
    public string BackgroundColor { get; set; } = string.Empty;
    public string SideNavColor { get; set; } = string.Empty;
    public string BannerText { get; set; } = string.Empty;
    public string CvLocation { get; set; } = string.Empty;


}


