using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CurrencyConverter.ViewModels
{
    class CurrencyConverterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

		public ICommand CountCommand { get; private set; }

        private int _count;

		public int Count
		{
			get { return _count; }
			set
			{
				_count = value;
				OnPropertyChanged();
			}
		}

        public CurrencyConverterViewModel()
        {
            CountCommand = new Command(
                execute: () =>
                {
                    Count++;
                });
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
