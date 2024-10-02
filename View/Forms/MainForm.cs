using AVT241LentaNovostey.Presenter;
using AVT241LentaNovostey.View.CustomControls;
using AVT241LentaNovostey.View.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AVT241LentaNovostey
{
    public partial class MainForm : Form, IMain
    {
        private readonly MainPresenter _presenter;
        public MainForm()
        {
            SuspendLayout();
            InitializeComponent();
            _presenter = new MainPresenter(this);
            LoadNews?.Invoke(this, EventArgs.Empty);
            ResumeLayout(true);
        }
        public event EventHandler LoadNews;
        public void BuildNews(List<NewsItem> news)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (NewsItem item in news)
            {
                flowLayoutPanel1.Controls.Add(item);
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите закрыть ленту?", "Закрытие ленты", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void AddNewsBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
