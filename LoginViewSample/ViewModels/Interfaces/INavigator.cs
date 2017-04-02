using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginViewSample.ViewModels
{
    /// <summary>
    /// This is an interface of any parent viewmodel in which it's children will effect its view.
    /// </summary>
    public interface INavigator
    {
        INavigationView CurrentView { get; set; }
        void Navigate(INavigationView viewModel);
    }
}
