using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class Book : INotifyPropertyChanged
    {
        private string title;
        private string author;
        private int year;
        private int rowid;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                RaisedChanged(nameof(Title));

            }
        }
        public string Author
        {
            get { return author; }
            set
            {
                author = value;
                RaisedChanged(nameof(Author));

            }
        }
        public int Year
        {
            get { return year; }
            set
            {
                year = value;
                RaisedChanged(nameof(Year));

            }
        }

        public int rowID
        {
            get { return rowid; }
            set
            {
                rowid = value;
                RaisedChanged(nameof(rowID));
            }
        }

        public Book(string title, string author, int year, int rowid)
        {
            this.Title = title;
            this.Author = author;
            this.Year = year;
            this.rowID = rowid;
        }


        private void RaisedChanged(string propname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
