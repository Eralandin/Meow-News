using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Schema;

namespace AVT241LentaNovostey.Model
{
    public class NewsItemText
    {
        private string title;
        private string content;
        private string date;
        private DateTime result;
        public NewsItemText(string title, string content, string date)
        {
            Title = title;
            Content = content;
            Date = date;
        }
        public string Title
        {
            get { return title; }
            set { 
                if (value.Length > 20)
                {
                    throw new ArgumentException("Длина заголовка не может быть больше 20 символов!");
                }
                else
                {
                    title = value;
                }
            }
        }
        public string Content
        {
            get { return content; }
            set {
                if (value.Length > 200)
                {
                    throw new ArgumentException("Новость слишком большая! Размер новости не должен превышать размер в 200 символов!");
                }
                else
                {
                    content = value;
                }
            }
        }
        public string Date
        {
            get { return date; }
            set
            {
                if (DateTime.TryParse(value, out result))
                {
                    date = DateTime.Parse(value).Date.ToShortDateString();
                }
                else
                {
                    throw new ArgumentException("Дата задана в неверном формате!");
                }
            }
        }
    }
}
