using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Main
{
    public class ListGenerics<TModel>
    {
        public List<TModel>? List { set; get; }
        public int ? Count { set; get; }
        public int ? CurrentPage { set; get; }
        public  string? SearchKeyword { set; get; }
        public bool Pagination { set; get; }=true;
        public string? data { set; get; }
    }
}
