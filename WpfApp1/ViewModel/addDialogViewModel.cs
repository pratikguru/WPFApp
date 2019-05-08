using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    
   

    class addDialogViewModel
    {
        public string TitleValue { get; set; }
        public string AuthorValue { get; set; }
        public string YearValue { get; set; }
        public string RowID { get; set; }
        internal void Save()
        {
            Console.WriteLine("Trying to save...");
            Book bk = new Book(TitleValue, AuthorValue, Convert.ToInt32(YearValue), Convert.ToInt32(RowID));
            var db = new dbHandler();
            
            db.insertBook(bk);
            var output = db.LoadData();
            while (output.Read())
            {
                Console.WriteLine("Author: " + output["year"] + "\t" + "Title: " + output["title"] + "\t" + "Year:" + output["year"]);
            }
            
        }

        internal void close()
        {
            Console.WriteLine("Closing...");
        }
    }
}
