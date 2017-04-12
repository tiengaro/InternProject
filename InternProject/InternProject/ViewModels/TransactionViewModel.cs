using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternProject.Models;

namespace InternProject.ViewModels
{
    public class TransactionViewModel : BaseViewModel
    {
        private Transaction _model;

        public TransactionViewModel()
        {
            _model = new Transaction {Date = DateTimeOffset.Now};
        }

        public Transaction Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged();
            }
        }

        public long Id
        {
            get => _model.Id;
            set
            {
                _model.Id = value;
                OnPropertyChanged();
            }
        }
        public string Description
        {
            get => _model.Description;
            set
            {
                _model.Description = value;
                OnPropertyChanged();
            }
        }
        public string Type
        {
            get => _model.Type;
            set
            {
                _model.Type = value;
                OnPropertyChanged();
            }
        }
        public double Price
        {
            get => _model.Price;
            set
            {
                _model.Price = value;
                OnPropertyChanged();
            }
        }
        public DateTimeOffset Date
        {
            get => _model.Date;
            set
            {
                _model.Date = value;
                OnPropertyChanged();
            }
        }
        public string Note
        {
            get => _model.Note;
            set
            {
                _model.Note = value;
                OnPropertyChanged();
            }
        }
    }
}
