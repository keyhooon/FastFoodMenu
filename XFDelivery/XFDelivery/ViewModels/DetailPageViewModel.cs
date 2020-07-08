using Prism.Navigation;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFDelivery.Models;
using XFDelivery.ViewModel;

namespace XFDelivery.ViewModels
{
    public class DetailPageViewModel : BaseViewModel, INavigationAware
    {
        public DetailPageViewModel()
        {
            PopDetailPageCommand = new Command(async () => await ExecutePopDetailPageCommand());
            AddQuantCommand = new Command(ExecuteAddQuantCommand);
            DeleteQuantCommand = new Command(ExecuteDeleteQuantCommand);

            Quant = 1;
        }

        public Command PopDetailPageCommand { get; }
        public Command AddQuantCommand { get; }
        public Command DeleteQuantCommand { get; }
        public Item Item { get => item; set => SetProperty(ref item, value); }

        private int _quant;
        private Item item;

        public int Quant
        {
            get { return _quant; }
            set { SetProperty(ref _quant, value); }
        }

        private async Task ExecutePopDetailPageCommand()
        {
        }

        private void ExecuteAddQuantCommand()
        {
            Quant += 1;
        }

        private void ExecuteDeleteQuantCommand()
        {
            if (Quant > 1)
                Quant -= 1;
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Item = parameters.GetValue<Item>("item");
        }

        protected override Task LoadDataAsync()
        {
            return Task.CompletedTask;
        }
    }
}
