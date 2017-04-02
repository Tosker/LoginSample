using LoginViewSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginViewSample.ViewModels
{
    /// <summary>
    /// The parent view model for the application.
    /// </summary>
    public class MainViewModel : ObservableObject, INavigator
    {
        //All child view models
        INavigationView loginViewModel = new LoginViewModel();

        //Current child being viewed
        private INavigationView _currentView;
        public INavigationView CurrentView
        {
            get { return _currentView; }
            set { OnPropertyChanged(ref _currentView, value); }
        }

        public MainViewModel()
        {
            //The 'ViewContext' property but be manually set for the initial view on application startup.
            loginViewModel.ViewContext = this;
            //Initialize first view on application startup
            CurrentView = loginViewModel;
        }

        //This is called by 'BaseViewModel.cs' (Contructor above being an exception)

        /// <summary>
        /// This navigates the 'CurrentView' property.
        /// </summary>
        /// <param name="viewModel">The new 'CurrentView' of this instance.</param>
        public void Navigate(INavigationView viewModel)
        {
            //If user is autheticated, freely navigate.
            //If user is not authenticated, navigate to login.
            if (CurrentView.AuthenticatedUser.IsAutheticated)
                CurrentView = viewModel;
            else
                CurrentView = loginViewModel;
        }
    }
}
