using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.DataTransferObjects.Setting
{
    public class SettingDto
    {
        public string Longitude { set; get; }
        public string Latitude { set; get; }
        public string? WorkingHours { set; get; }
        public string? Id { set; get; }
        public string? Email { set; get; }

        public string? PhoneNumber { set; get; }

        public string? Address { set; get; }

        public string? Logo { set; get; }

        public IFormFile? LogoFile { set; get; }

        public string? Description { set; get; }

        public string? SiteTitle { set; get; } 

        public string? AboutDescription { set; get; }
        public string? FooterDescription { set; get; }
        public string? PartnerDescription { set; get; }

        public string? ServiceDescription { set; get; }

        public string? TeamDescription { set; get; }

        public string? ProjectDescription { set; get; }

        public string? Banner { set; get; }

        public IFormFile? BannerFile { set; get; }

        public string? Linkedin { set; get; }

        public string? Twitter { set; get; }

        public string? FaceBook { set; get; }

        public string? Instagram { set; get; }
        public IFormFile? AboutImageFile { set; get; }
        public string? AboutImage { set; get; }
        public string? WorkExperience { set; get; }
        public string? CompletedProject { set; get; }
        public string? BannerPageHeader { set; get; }
        public IFormFile? BannerPageHeaderFile { set; get; }
        public string? MailSender { set; get; }
        public string? MailReceiver { set; get; }
        public string? MailHost { set; get; }
        public string? SmtpUserName { set; get; }
        public string? SmtpPassword { set; get; }
        public int MailHostPort { set; get; } = 0;
        public bool ActiveMailService { set; get; }

        public string CategoryBanner { set; get; }
        public string WorkWithBanner { set; get; }
        public string RequestBanner { set; get; }
        public string ContactBanner { set; get; }
        public string ProjectBanner { set; get; }
        public string AboutBanner { set; get; }

        public IFormFile? FileCategoryBanner { set; get; }
        public IFormFile? FileWorkWithBanner { set; get; }
        public IFormFile? FileRequestBanner { set; get; }
        public IFormFile? FileContactBanner { set; get; }
        public IFormFile? FileProjectBanner { set; get; }
        public IFormFile? FileAboutBanner { set; get; }
    }
}
