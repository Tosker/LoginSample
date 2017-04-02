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
    /// This is a BaseViewModel sample, that implements the INavigationView.
    /// Child view models that will influence navigation will derive from this.
    /// </summary>
    public class BaseViewModel : ObservableObject, INavigationView
    {
        private User _authUser = new User(string.Empty);

        /// <summary>
        /// This is a property for demonstration -- this is not important.
        /// </summary>
        public User AuthenticatedUser
        {
            get { return _authUser; }
            set { OnPropertyChanged(ref _authUser, value); }
        }

        /// <summary>
        /// The parent in which this childs navigation will affect.
        /// </summary>
        public INavigator ViewContext { get; set; }
        public ICommand NavigateCommand { get; set; }

        public BaseViewModel()
        {
            NavigateCommand = new NavigateCommand(Navigate);
        }


        /// <summary>
        /// Calls for a navigation change to it's parent -- which holds the view binded property.
        /// </summary>
        /// <typeparam name="T">Any view model that implements INavigationView</typeparam>
        /// <param name="context">The instance of the view model to navigate to.</param>
        public void Navigate(INavigationView context)
        {
            //Ensures the new view has the same parent context for future navigation.
            context.ViewContext = ViewContext;
            context.AuthenticatedUser = AuthenticatedUser;
            //Tell the parent to navigate to the new view.
            ViewContext.Navigate(context);
        }
    }
}
