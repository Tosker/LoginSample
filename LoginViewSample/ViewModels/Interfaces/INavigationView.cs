using LoginViewSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LoginViewSample.ViewModels
{
    /// <summary>
    /// This is an interface for a child view model that will be navigated to.
    /// </summary>
    public interface INavigationView
    {
        /// <summary>
        /// This is for demonstration. Assuming authentication is needed for navigation.
        /// </summary>
        User AuthenticatedUser { get; set; }

        ICommand NavigateCommand { get; set; }

        INavigator ViewContext { get; set; }
        void Navigate(INavigationView context);
    }
}
