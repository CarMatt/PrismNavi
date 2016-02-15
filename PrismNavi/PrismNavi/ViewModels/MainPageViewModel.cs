using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PrismNavi.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private readonly INavigationService _navigationService;
        public DelegateCommand ModalDelegateCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            ModalDelegateCommand = new DelegateCommand(NavigateModal);
        }
        private void NavigateModal()
        {
            NavigationParameters parameters = new NavigationParameters();
            parameters.Add("key1", "value1");
            _navigationService.Navigate("PrismContentPage1", parameters, true);
        }


        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            Debug.WriteLine("-------------MainPageViewModel----------OnNavigatedFrom -->");
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Debug.WriteLine("-------------MainPageViewModel----------OnNavigatedTo <--");

            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }
    }
}
