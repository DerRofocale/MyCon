using Microsoft.EntityFrameworkCore;
using MyCon.DBContext;
using MyCon.Models;
using MyCon.Views.Windows;
using Prism.Commands;
using Prism.Mvvm;

namespace MyCon.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private MyConDbContext DbContext = new MyConDbContext();
        public MainWindowViewModel()
        {
            Organizations = DbContext.Organizations.Include(x => x.Connections).ToList();
        }

        private Organization? _selectedOrganization;
        public Organization? SelectedOrganization
        {
            get { return _selectedOrganization; }
            set
            {
                if (_selectedOrganization != value)
                    SetProperty(ref _selectedOrganization, value);
            }
        }

        private List<Organization>? _organizations = new List<Organization>();
        public List<Organization>? Organizations
        {
            get { return _organizations; }
            set { SetProperty(ref _organizations, value); }
        }

        private Connection? _selectedConnection;
        public Connection? SelectedConnection
        {
            get { return _selectedConnection; }
            set { SetProperty(ref _selectedConnection, value); }
        }

        private DelegateCommand<string?> _findOrganizationsBySearchQueryCommand;
        public DelegateCommand<string?> FindOrganizationsBySearchQueryCommand =>
            _findOrganizationsBySearchQueryCommand ?? (_findOrganizationsBySearchQueryCommand = new DelegateCommand<string?>(FilterOrganizationsList));

        void FilterOrganizationsList(string? parameter)
        {
            if (!string.IsNullOrEmpty(parameter))
            {
                /*TODO: Сделать ToLower();*/
                Organizations = DbContext.Organizations.Include(x => x.Connections).Where(x => x.Name.Contains(parameter)).ToList();
            }
            else
            {
                Organizations = DbContext.Organizations.Include(x => x.Connections).ToList();
            }
        }

        private DelegateCommand _addNewOrganizationCommand;
        public DelegateCommand AddNewOrganizationCommand =>
            _addNewOrganizationCommand ?? (_addNewOrganizationCommand = new DelegateCommand(ExecuteAddNewOrganizationCommand));

        void ExecuteAddNewOrganizationCommand()
        {
            new AddNewOrganizationWindow(DbContext).ShowDialog();
            FilterOrganizationsList(null);
        }
    }

    class CustomStringComparer : IEqualityComparer<string>
    {
        public bool Equals(string? x, string? y)
        {
            if (x is null || y is null) return false;
            return x.ToLower() == y.ToLower();

        }

        public int GetHashCode(string obj) => obj.ToLower().GetHashCode();
    }
}
