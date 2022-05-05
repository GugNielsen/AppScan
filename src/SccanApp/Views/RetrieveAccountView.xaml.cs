using SccanApp.Models;
using SccanApp.ViewModels;

namespace SccanApp;

public partial class RetrieveAccountView : ContentPage
{
    public RetrieveAccountView()
    {
        InitializeComponent();
        this.BindingContext = new RetrieveAccountViewModel();
    }

    //public RetrieveAccountView(User user)
    //{
    //    InitializeComponent();
    //    this.BindingContext = new RetrieveAccountViewModel(user);
    //}
}