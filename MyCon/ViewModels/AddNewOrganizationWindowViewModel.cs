using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCon.DBContext;
using Prism.Mvvm;

namespace MyCon.ViewModels
{
    public class AddNewOrganizationWindowViewModel : BindableBase
    {
        private MyConDbContext DBContext;
        public AddNewOrganizationWindowViewModel(MyConDbContext _db)
        {
            DBContext = _db;
        }

    }
}
