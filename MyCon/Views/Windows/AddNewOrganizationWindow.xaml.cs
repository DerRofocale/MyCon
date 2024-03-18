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
using MyCon.DBContext;
using MyCon.ViewModels;

namespace MyCon.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddNewOrganizationWindow.xaml
    /// </summary>
    public partial class AddNewOrganizationWindow : Window
    {
        public AddNewOrganizationWindow(MyConDbContext _db)
        {
            InitializeComponent();
            this.DataContext = new AddNewOrganizationWindowViewModel(_db);
        }
    }
}
