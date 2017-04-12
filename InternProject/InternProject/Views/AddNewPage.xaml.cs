﻿using InternProject.Services;
using InternProject.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InternProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewPage : ContentPage
    {
        public AddNewPage()
        {
            BindingContext = new AddNewPageViewModel(new PageService());
            InitializeComponent();
        }
    }
}