using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels.Sender;

namespace Application.Services.Sender
{
    public interface ISender
    {
        Task SendAsync(SenderViewModel model);
    }
}
