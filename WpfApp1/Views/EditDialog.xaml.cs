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
using System.Windows.Shapes;
using WpfApp1.ViewModel;
using WpfApp1.Model;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class EditDialog
    {
        public class CloseEventArgs : EventArgs
        {
            Book Book
            {
                get;
                set;
            }
        }
        private editDialogViewModel xm;

        public EditDialog(string title, string author, string year, int index)
        {
            InitializeComponent();
            xm = new editDialogViewModel(title, author, year, index);
            DataContext = xm;
        }

        void closeHandler(object sender, EventArgs e)
        {
            DialogResult = false;
            xm.close();
            this.Close();
        }

        void saveHandler(object sender, EventArgs e)
        {
            DialogResult = true;
            xm.Save();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
