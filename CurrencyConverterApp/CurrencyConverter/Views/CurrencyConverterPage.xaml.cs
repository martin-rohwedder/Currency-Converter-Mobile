using CurrencyConverter.ViewModels;

namespace CurrencyConverter.Views;

public partial class CurrencyConverterPage : ContentPage
{
	public CurrencyConverterPage(CurrencyConverterViewModel currencyConverterViewModel)
	{
		BindingContext = currencyConverterViewModel;
		InitializeComponent();
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();
		await (BindingContext as CurrencyConverterViewModel).LoadDataAsync();
    }
}