using AVT241LentaNovostey.Model;
using AVT241LentaNovostey.View.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AVT241LentaNovostey.View.CustomControls
{
    public partial class NewsItem : UserControl
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Вычмат\Прога\AVT241LentaNovostey\AVT241News.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public NewsItem()
        {
            InitializeComponent();
        }
        public void Build(NewsItemText news)
        {
            label1.Text = news.Title;
            label2.Text = news.Date;
        }

        private void CheckNewsBtn_Click(object sender, EventArgs e)
        {
            try
            {
                NewsForm newsForm = new NewsForm();
                cm = new SqlCommand("SELECT * FROM NewsItems WHERE Title LIKE N'%" + label1.Text +"%'",con);
                con.Open();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    newsForm.TitleTextBox.Text = dr[0].ToString();
                    newsForm.ContentRichTextBox.Text = dr[1].ToString();
                }
                dr.Close();
                con.Close();
                cm = new SqlCommand("SELECT * FROM Commentary WHERE Title LIKE N'%"+label1.Text +"%'",con);
                con.Open();
                dr = cm.ExecuteReader();
                while(dr.Read())
                {
                    NewsItem newsItem = new NewsItem();
                    newsItem.label1.Text = dr[0].ToString();
                    newsItem.label3.Text = dr[1].ToString();
                    newsItem.label2.Text = dr[2].ToString();
                    newsItem.CheckNewsBtn.Visible = false;
                    newsItem.label3.Location = new Point(5,40);
                    newsItem.label2.Location = new Point(4,100);
                    newsForm.Commentary.Controls.Add(newsItem);
                }
                dr.Close();
                con.Close();
                newsForm.ShowDialog();
                
            }
            catch (Exception ex)
            {
                dr.Close();
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
