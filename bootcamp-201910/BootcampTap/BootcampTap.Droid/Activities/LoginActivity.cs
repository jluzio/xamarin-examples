using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BootcampTap.Core;
using BootcampTap.Core.ViewModels;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace BootcampTap.Droid.Activities
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : ActivityBase
    {
        LoginViewModel _viewModel;
        private EditText _username;
        private EditText _password;
        private ProgressBar _progressBar;
        private Button _loginButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_login);

            _viewModel = App.Container.GetInstance<LoginViewModel>();

            _username = FindViewById<EditText>(Resource.Id.Username);
            _password = FindViewById<EditText>(Resource.Id.Password);
            _progressBar = FindViewById<ProgressBar>(Resource.Id.ProgressBar);
            _loginButton = FindViewById<Button>(Resource.Id.LoginButton);

            _username.Text = _viewModel.Username;
            _password.Text = _viewModel.Password;
            _progressBar.Visibility = _viewModel.IsBusy ? ViewStates.Visible : ViewStates.Invisible;

            // if used OnResume, need to remove it first, then add it (no need in OnCreate)
            _username.TextChanged -= _username_TextChanged;
            _username.TextChanged += _username_TextChanged;

            _password.TextChanged -= _password_TextChanged;
            _password.TextChanged += _password_TextChanged;

            _viewModel.PropertyChanged -= _viewModel_PropertyChanged;
            _viewModel.PropertyChanged += _viewModel_PropertyChanged;

            _loginButton.Click -= _loginButton_Click;
            _loginButton.Click += _loginButton_Click;

            _viewModel.LoginCommand.CanExecuteChanged += LoginCommand_CanExecuteChanged;

            _loginButton.Enabled = _viewModel.LoginCommand.CanExecute(null);
        }

        private void LoginCommand_CanExecuteChanged(object sender, EventArgs e)
        {
            _loginButton.Enabled = _viewModel.LoginCommand.CanExecute(null);
        }

        private void _loginButton_Click(object sender, EventArgs e)
        {
            if (_viewModel.LoginCommand.CanExecute(null))
                _viewModel.LoginCommand.ExecuteAsync();
        }

        private void _viewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.Username))
                _username.Text = _viewModel.Username;
            else if (e.PropertyName == nameof(_viewModel.Password))
                _password.Text = _viewModel.Password;
            else if (e.PropertyName == nameof(_viewModel.IsBusy))
                _progressBar.Visibility = _viewModel.IsBusy ? ViewStates.Visible : ViewStates.Invisible;
        }

        private void _username_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            _viewModel.SetUsernameCommand.Execute(_username.Text);
        }

        private void _password_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            _viewModel.SetPasswordCommand.Execute(_password.Text);
        }
    }
}