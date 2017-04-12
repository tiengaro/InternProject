using InternProject.Models;

namespace InternProject.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        private User _model;

        public UserViewModel()
        {
            _model = new User();
        }

        public User Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged();
            }
        }

        public string UsernameModel
        {
            get => _model.Username;
            set
            {
                _model.Username = value;
                OnPropertyChanged();
            }
        }

        public string PasswordModel
        {
            get => _model.Password;
            set
            {
                _model.Password = value;
                OnPropertyChanged();
            }
        }

        public string PhoneModel
        {
            get => _model.Phone;
            set
            {
                _model.Phone = value;
                OnPropertyChanged();
            }
        }
    }
}