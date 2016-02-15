using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Prism.Navigation;

namespace PrismNavi.ViewModels
{
    public class PrismContentPage1ViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;

        public DelegateCommand PopDelegateCommand { get; set; }


        public PrismContentPage1ViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            PopDelegateCommand = new DelegateCommand(Pop);

        }

        private void Pop()
        {
            NavigationParameters parameters = new NavigationParameters();
            parameters.Add("key2", "value2");
            _navigationService.GoBack(parameters, true);

        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            Debug.WriteLine("-------------PrismContentPage1----------OnNavigatedFrom -->");
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Debug.WriteLine("-------------PrismContentPage1----------OnNavigatedTo <--");
        }


    }
}
