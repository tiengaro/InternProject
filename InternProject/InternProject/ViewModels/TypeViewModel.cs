using InternProject.Models;

namespace InternProject.ViewModels
{
    public class TypeViewModel : BaseViewModel
    {
        private TypeTransaction _model;

        public TypeViewModel()
        {
            _model = new TypeTransaction();
        }

        public TypeTransaction Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged();
            }
        }

        public int IdTypeModel
        {
            get => _model.IdType;
            set
            {
                _model.IdType = value;
                OnPropertyChanged();
            }
        }

        public string TypeNameModel
        {
            get => _model.TypeName;
            set
            {
                _model.TypeName = value;
                OnPropertyChanged();
            }
        }
    }
}