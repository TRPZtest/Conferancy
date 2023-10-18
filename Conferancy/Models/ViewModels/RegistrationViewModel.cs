using Conference.Data.Db;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Conference.Models.ViewModels
{  
    public class RegistrationViewModel 
    {       
        [Required]
        public string FirstName { get; set; }     
        public string LastName { get; set; }
        public string Password { get; set; }
        [Remote("IsEmailUnique", "Conference", "Email alrady in use")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int RegionId { get; set; }
        public List<Region> Regions { get; set; } = new List<Region>();
    }
     
    //    <div class="form-group">
    //    @Html.LabelFor(model => model.RegionId, htmlAttributes: new { @class = "control-label col-md-2" })
    //    < div class= "col-md-10" >
    //         @Html.DropDownListFor(model => model.RegionId, new SelectList(Model.Regions.ToDictionary(x => x.Id, x => x.Name), "Key", "Value"), "--Select--", new { htmlAttributes = new { @class = "form-control" } })
    //        @Html.ValidationMessageFor(model => model.RegionId, "", new { @class = "text-danger" })
    //    </ div >
    //</ div >
}
