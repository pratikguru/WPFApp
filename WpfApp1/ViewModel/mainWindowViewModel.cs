using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    class mainWindowViewModel
    {
        public List<Book> BookBuffer
        {
            get; set;
        }

       
      
        public mainWindowViewModel()
        {
            BookBuffer = new List<Book>();
           
            Console.WriteLine("Writing from dm.");
            Load();
            
        }

        public List<Book>  Load()
        {
            var db = new dbHandler();
            var output = db.LoadData();
           
            List<Book> bk = new List<Book>();
            while (output.Read())
            {
                Console.WriteLine("Author: " + output["Author"] + "\t" + "Title: " + output["title"] + "\t" + "Year:" + output["year"] + "\t" + output["rowid"]);
                bk.Add(new Book(Convert.ToString(output["Title"]), Convert.ToString(output["Author"]), Convert.ToInt32(output["Year"]), Convert.ToInt32(output["rowid"])));
            }
            BookBuffer = bk;
            return BookBuffer;
        }

        internal List<Book> filter(List<Book> BookList)
        {
            Console.WriteLine("Filtering");
            BookBuffer = BookList;
            return BookBuffer;
        }

        internal void fillTable()
        {
            Load();
            return;
        }
    }
}
