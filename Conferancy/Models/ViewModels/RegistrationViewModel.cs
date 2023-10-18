using Conference.Data.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conference.Models.ViewModels
{
    public class RegistrationViewModel : User
    {
        public List<Region> Regions { get; set; } = new List<Region>();
    }
}
