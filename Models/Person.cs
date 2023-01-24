using System.ComponentModel.DataAnnotations;

namespace IdentityApp.Models;

public class Person
{
    public long Id { get; set; }
    [Required(ErrorMessage = "Please enter a name")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Please enter a surname")]
    public string Surname { get; set; }
    [Required(ErrorMessage = "Please enter birth")]
    public DateTime Birth { get; set; }
    [Required(ErrorMessage = "Please enter a profession")]
    public string Profession { get; set; }
    [Required(ErrorMessage = "Please enter a workplace")]
    public string Workplace { get; set; }
    [Required(ErrorMessage = "Please enter a eductaion institute")]
    public string EducationInstitute { get; set; }
    [Required(ErrorMessage = "Please set education degree")]
    public string EducationDegree { get; set; }
    [Required(ErrorMessage = "Please enter employment")]
    public string Employment { get; set; }
    public string PhoneNumb { get; set; } = string.Empty;
    [EmailAddress]
    [Required(ErrorMessage = "Email is mandatory")]
    public string EmailAddress { get; set; } = string.Empty;
    
    public string CvDoc { get; set; } = string.Empty;
    public List<Record> Records { get; set; } = new List<Record>();
    

}



