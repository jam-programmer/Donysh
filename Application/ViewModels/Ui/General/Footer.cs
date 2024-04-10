using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Ui.General
{
    public class Footer
    {
        public string? WorkingHours { set; get; }
        public AboutAndMedia? ColumnOne { set; get; }
        public List<Pages>? ColumnTwo { set; get; }
    }
}
