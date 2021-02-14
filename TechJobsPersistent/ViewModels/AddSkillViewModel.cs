using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace TechJobsPersistent.ViewModels
{
    public class AddSkillViewModel
    {
        [Required(ErrorMessage = "Skill is required")]
        public string Name { get; set; }
        public string Description { get; set; }

        public AddSkillViewModel()
        {
        }

     
    }
}
