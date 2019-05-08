using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    class editDialogViewModel
    {
        public string TitleValue { get; set; }
        public string AuthorValue { get; set; }
        public string YearValue { get; set; }
        public int    selectedIndex { get; set; }
        
        public editDialogViewModel()
        {

        }

        public editDialogViewModel(string title, string author, string year, int index)
        {
            this.TitleValue = title;
            this.AuthorValue = author;
            this.YearValue = year;
            this.selectedIndex = index;
        }

        internal void Save()
        {
            Console.WriteLine("Trying to save...");
            Console.WriteLine(this.selectedIndex);
            var db = new dbHandler();
            db.EditAuthor(this.AuthorValue, this.selectedIndex);
            db.EditTitle(this.TitleValue, this.selectedIndex);
            db.EditYear(Convert.ToInt32(this.YearValue), this.selectedIndex);
        }

        internal void close()
        {
            Console.WriteLine("Closing...");
        }
    }
}
