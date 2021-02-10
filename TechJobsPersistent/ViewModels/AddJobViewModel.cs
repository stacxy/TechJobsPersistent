﻿using Microsoft.AspNetCore.Mvc.Rendering;
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

        [Required(ErrorMessage = "Employer is required")]
        public int EmployerId { get; set; }

        
        public List<SelectListItem> Employer { get; set; }

        public AddJobViewModel(List<Employer> employers)
        {
            Employer = new List<SelectListItem>();

            foreach (var employer in employers)
            {
                Employer.Add(new SelectListItem
                {
                    Value = employer.Id.ToString(),
                    Text = employer.Name
                });
            }



        }

        public AddJobViewModel()
        {

        }

    }
}
