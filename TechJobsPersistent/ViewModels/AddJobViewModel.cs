using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TechJobsPersistent.Models;

namespace TechJobsPersistent.ViewModels
{
    public class AddJobViewModel
    {
        [Required(ErrorMessage = "Job is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required")]
        public int EmployerId { get; set; }

        public List<SelectListItem> Skills { get; set; }

        public List<SelectListItem> Employer { get; set; }

        public AddJobViewModel(List<Employer> employers, List<Skill> skills)
        {
            Skills = new List<SelectListItem>();

            foreach (var skill in skills)
            {
                Skills.Add(new SelectListItem
                {
                    Value = skill.Id.ToString(),
                    Text = skill.Name
                });
            }

            Employer = new List<SelectListItem>();

            foreach (var employer in employers)
            {
                Employer.Add(new SelectListItem
                {
                    Value = employer.Id.ToString(),
                    Text = employer.Name
                }) ;
            }
        }

        public AddJobViewModel()
        {

        }

    }
}
