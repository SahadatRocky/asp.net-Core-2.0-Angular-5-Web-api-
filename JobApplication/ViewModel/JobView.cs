using JobApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobApplication.ViewModel
{
    public class JobView
    {
     

        public int DeveloperjobId { get; set; }
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }
        public virtual CompanyAddress CompanyAddress { get; set; }
        public string SalaryRange { get; set; }
        public string JobTypeName { get; set; }
        public string ExperienceLavel { get; set; }
       
        public string IndustryName { get; set; }
        public int CompanySize { get; set; }
        public string CompanyTypeName { get; set; }
        public DateTime CreatedDate { get; internal set; }
    }
}
