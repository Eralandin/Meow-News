using AVT241LentaNovostey.View.CustomControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVT241LentaNovostey.View.Interfaces
{
    public interface IMain
    {
        event EventHandler LoadNews;
        void BuildNews(List<NewsItem> news);
    }
}
