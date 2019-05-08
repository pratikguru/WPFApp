using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Model;
using WpfApp1.ViewModel;
using static WpfApp1.Views.addDialog;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {

        mainWindowViewModel mn = new mainWindowViewModel();
        public bool filterTurnedOn = false;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = mn;
            UpdateYears();
        }

        private mainWindowViewModel mainModel;

        void onAddClick(object sender, EventArgs e)
        {
            
            Console.WriteLine("Clicked..");
            var addDialog = new addDialog();
            
            bool? result = addDialog.ShowDialog();
            
            
            if (result == true)
            {
                listView.ItemsSource = mn.Load();
                
                Console.WriteLine("Saved.");
            }
            else
            {
                Console.WriteLine("Closed.");
            }
            UpdateYears();
        }

       
        void onEditClick(object sender, EventArgs e)
        {
            
            
            int selectedCount = listView.SelectedItems.Count;
            Book foo = (Book)listView.SelectedItem;
            if (selectedCount > 1)
            {
                MessageBox.Show("Max selection allowed for Edit is only 1!");
                return;
            }

            var EditDialog = new EditDialog(foo.Title, foo.Author, Convert.ToString(foo.Year), foo.rowID);
            Console.WriteLine("Edit made..");
            EditDialog.ShowDialog();
            listView.ItemsSource = mn.Load();            
            UpdateYears();
        }

        void onDeleteClick(object sender, EventArgs e)
        {
            
            int selectedCount = listView.SelectedItems.Count;

            if(selectedCount != 0)
            {
                var db = new dbHandler();
                foreach(Book bk in listView.SelectedItems){
                    db.DeleteRecord(bk.rowID);
                }
                
                Console.WriteLine("Items to delete: " + selectedCount);
                listView.ItemsSource = mn.Load();
                
            }
            else if(selectedCount == 0)
            {
                MessageBox.Show("A minimum selection is needed for deleting!");
            }
            UpdateYears();
        }


        void filterOnClick(object sender, EventArgs e)
        {
            filterTurnedOn = true;
            Console.WriteLine("Filter on click called.");
            string sql = "";
            if((titleFilter.Text).Length > 1 && (authorFilter.Text).Length > 1 && (yearBuffer.SelectedItem) != null )
            {
                Console.WriteLine("Filtering YEAR, AUTHOR AND TITLE");
                sql = $"SELECT rowid, *FROM BOOK WHERE AUTHOR ='{authorFilter.Text}' AND YEAR ={yearBuffer.SelectedItem} AND TITLE='{titleFilter.Text}'";
            }
            else if ((titleFilter.Text).Length > 1 && (authorFilter.Text).Length > 1)
            {
                Console.WriteLine("Filtering TITLE AND AUTHOR");
                sql = $"SELECT rowid,* FROM BOOK WHERE AUTHOR='{authorFilter.Text}' and TITLE='{titleFilter.Text}'";
            }
            else if ((authorFilter.Text).Length > 1 && (yearBuffer.SelectedItem != null))
            {
                Console.WriteLine("Filtering AUTHOR and YEAR.");
                sql = $"SELECT rowid,* FROM BOOK WHERE AUTHOR='{authorFilter.Text}' and YEAR={yearBuffer.SelectedItem}";
            }
            else if((titleFilter.Text).Length > 1 && (yearBuffer.SelectedItem) != null)
            {
                Console.WriteLine("Filtering TITLE and YEAR");
                sql = $"SELECT rowid,* FROM BOOK WHERE TITLE='{titleFilter.Text}' and YEAR={yearBuffer.SelectedItem}";
            }
            else if((titleFilter.Text).Length > 1)
            {
                sql = $"SELECT rowid,* FROM BOOK WHERE TITLE='{titleFilter.Text}'";
            }
            else if((authorFilter.Text).Length > 1) {
                Console.WriteLine("Filtering AUTHOR");
                sql = $"SELECT rowid,* FROM BOOK WHERE AUTHOR='{authorFilter.Text}'";
            }
            else if ((yearBuffer.SelectedItem) != null)
            {
                Console.WriteLine("Filtering YEAR");
                sql = $"SELECT rowid,* FROM BOOK WHERE YEAR={yearBuffer.SelectedItem}";
            }
            else
            {
                Console.WriteLine("Filtering not set.");
                return;
            }

            var db = new dbHandler();
            listView.ItemsSource = mn.filter(db.loadFilters(sql));

            
        }

        void clearOnClick(object sender, EventArgs e)
        {
            Console.WriteLine("Clear on click called.");
            listView.ItemsSource = mn.Load();
            titleFilter.Text  = "";
            authorFilter.Text = "";
            UpdateYears();
            yearBuffer.SelectedItem = null;
            this.filterTurnedOn = false;
        }

        void UpdateYears()
        {
            var db = new dbHandler();
           
            yearBuffer.ItemsSource = db.LoadYears();
            return;
        }

    }   
}

