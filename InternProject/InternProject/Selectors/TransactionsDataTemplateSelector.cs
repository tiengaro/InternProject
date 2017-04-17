using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternProject.Models;
using InternProject.ViewModels;
using Xamarin.Forms;

namespace InternProject.Selectors
{
    public class TransactionsDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ShoppingTemplate { get; set; }
        public DataTemplate EatingTemplate { get; set; }
        public DataTemplate DrinkingTemplate { get; set; }
        public DataTemplate FuelTemplate { get; set; }
        public DataTemplate OtherTemplate { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var type = ((TransactionViewModel) item).Type;
            DataTemplate templateSelector;
            switch (type)
            {
                case "Shopping":
                    templateSelector = ShoppingTemplate;
                    break;
                case "Eating":
                    templateSelector = EatingTemplate;
                    break;
                case "Drinking":
                    templateSelector = DrinkingTemplate;
                    break;
                case "Fuel":
                    templateSelector = FuelTemplate;
                    break;
                case "Other":
                    templateSelector = OtherTemplate;
                    break;
                default:
                    templateSelector = OtherTemplate;
                    break;
            }
            return templateSelector;
        }
    }
}
