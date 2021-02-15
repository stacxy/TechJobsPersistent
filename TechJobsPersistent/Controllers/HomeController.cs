using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;
using TechJobsPersistent.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TechJobsPersistent.Controllers
{
    public class HomeController : Controller
    {
        private JobDbContext context;

        public HomeController(JobDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Job> jobs = context.Jobs.Include(j => j.Employer).ToList();

            return View(jobs);
        }

        [HttpGet("/Add")]
        public IActionResult AddJob()
        {
            List<Skill> skills = context.Skills.ToList();
            List<Employer> employers = context.Employers.ToList();
            AddJobViewModel addJobViewModel = new AddJobViewModel(employers, skills);
            return View(addJobViewModel);
        }

        [HttpPost]
     
        public IActionResult ProcessAddJobForm(AddJobViewModel viewModel, string[] selectedSkills)
        { 
            
            if (ModelState.IsValid)
            {
                Employer employer = context.Employers.Find(viewModel.EmployerId);
                List<JobSkill> jobSkills = new List<JobSkill>();
                Job newJob = new Job()
                {
                    Name = viewModel.Name,
                    Employer = employer,
                    JobSkills = jobSkills
                };
      
                for (var i = 0; i < selectedSkills.Length; i++)
                {
                    int skillId = int.Parse(selectedSkills[i]);
                    int jobId = newJob.Id;
                   
                        JobSkill jobSkill = new JobSkill()
                        {
                            JobId = jobId,
                            SkillId = skillId
                        };
                       
                        newJob.JobSkills.Add(jobSkill);

                }
                context.Jobs.Add(newJob);
                context.SaveChanges(); 

                return Redirect("Index");
            }
          
            return View("AddJob", RePop(viewModel));
        } 
        
        public IActionResult Detail(int id)
        {
            Job theJob = context.Jobs
                .Include(j => j.Employer)
                .Single(j => j.Id == id);

            List<JobSkill> jobSkills = context.JobSkills
                .Where(js => js.JobId == id)
                .Include(js => js.Skill)
                .ToList();

            JobDetailViewModel viewModel = new JobDetailViewModel(theJob, jobSkills);
            return View(viewModel);
        }

        //repopulates view if modelstate invalid
        private AddJobViewModel RePop(AddJobViewModel mod)
        {
            List<Skill> skills = context.Skills.ToList();
            List<Employer> employers = context.Employers.ToList();
            AddJobViewModel addJobViewModel = new AddJobViewModel(employers, skills)
            {
                Name = mod.Name
            };
            
            return addJobViewModel;
        }

       
    }
   

}
