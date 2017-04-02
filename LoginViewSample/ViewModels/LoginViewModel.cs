using LoginViewSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace LoginViewSample.ViewModels
{
    /// <summary>
    /// Login view model for user authentication.
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        /// <summary>
        /// Artificial connection class for this demonstration.
        /// </summary>
        private ConnectionManager _connection;

        /// <summary>
        /// Command for authenticating the user.
        /// </summary>
        public ICommand LoginCommand { get; set; }

        /// <summary>
        /// Username of the attempting login.
        /// </summary>
        private string _username;
        public string Username
        {
            get { return _username; }
            set { OnPropertyChanged(ref _username, value); }
        }

        /// <summary>
        /// Users secret of the attempting login.
        /// </summary>
        private SecureString _secret;
        public SecureString Secret
        {
            get { return _secret; }
            set { OnPropertyChanged(ref _secret, value); }
        }

        public LoginViewModel()
        {
            //Initial instances
            _connection = new ConnectionManager();
            LoginCommand = new RelayCommand(Login);
        }

        /// <summary>
        /// Authenticates the user provided info.
        /// </summary>
        /// <param name="param">INavigationView to navigate to if authenticated</param>
        private void Login(object param)
        {
            //I only did it this way because I'm trying to prevent a plain text value of the password in memory.
            //Though dependency on UI breaks a pattern, it may be neccessary for security.
            var secretBox = param as PasswordBox;
            var secret    = secretBox.SecurePassword;
            var success   = _connection.Authenticate(Username, secret);

            if(success)
            {
                //This is for demonstration. Not required
                AuthenticatedUser = new User(Username);
                AuthenticatedUser.IsAutheticated = true;

                //Call BaseViewModel Navigate, which then calls parent navigation.
                Navigate(new HomeViewModel());
            }
        }
    }
}
