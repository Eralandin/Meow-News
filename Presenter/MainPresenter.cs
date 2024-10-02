using AVT241LentaNovostey.Model;
using AVT241LentaNovostey.View.CustomControls;
using AVT241LentaNovostey.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AVT241LentaNovostey.Presenter
{
    public class MainPresenter
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Вычмат\Прога\AVT241LentaNovostey\AVT241News.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        private readonly IMain _view;
        private User _user;
        public MainPresenter(IMain view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _view.LoadNews += LoadNews;
        }
        private void LoadNews(object sender, EventArgs e)
        {
            List<NewsItemText> textItems = new List<NewsItemText>();
            cm = new SqlCommand("SELECT * FROM NewsItems", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                textItems.Add(new NewsItemText(dr[0].ToString(), dr[1].ToString(), dr[2].ToString()));
            }
            List<NewsItem> buildedItems = new List<NewsItem>();
            foreach (var item in textItems)
            {
                NewsItem newItem = new NewsItem();
                newItem.Build(item);
                buildedItems.Add(newItem);
            }
            _view.BuildNews(buildedItems);
        }
    }
}
