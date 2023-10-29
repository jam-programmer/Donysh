using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Mapping.Register
{
    public static class RegisterMapping
    {
        public static void AddMapping(ModelBuilder builder)
        {
            
            builder.ApplyConfiguration(new AboutMapping());
            builder.ApplyConfiguration(new ScopeWorkMapping());
            builder.ApplyConfiguration(new CompanyMapping());
            builder.ApplyConfiguration(new ProjectMapping());
            builder.ApplyConfiguration(new RequestMapping());
            builder.ApplyConfiguration(new ServiceMapping());
            builder.ApplyConfiguration(new StatusMapping());
            builder.ApplyConfiguration(new TeamMapping());
            builder.ApplyConfiguration(new SettingMapping());
        }

    }
}
