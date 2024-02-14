using CvAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Domain.Entities
{
    public class CvPart:BaseEntity
    {
        public int CvInformationId { get; set; }
        public CvInformation CvInformation { get; set; }
        public string Name { get; set; }
        public string? IconPath { get; set; }
        public string? IconName { get; set; }
        public int Order { get; set; }
        public bool IsContactInfo { get; set; }

        public ICollection<GeneralArticle> GeneralArticles { get; set; }
        public ICollection<Education> Educations { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<Certificate> Certificates { get; set; }
        public ICollection<SocialMedia> SocialMedias { get; set; }
        public ICollection<Skill> Skills { get; set; }
        public ICollection<WorkExperience> WorkExperiences { get; set; }
        public ICollection<Hobby> Hobbies { get; set; }
    }
}
