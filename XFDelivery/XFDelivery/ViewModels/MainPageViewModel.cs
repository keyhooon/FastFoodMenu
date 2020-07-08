using Prism.Commands;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using XFDelivery.Models;
using XFDelivery.Service;
using XFDelivery.ViewModel;
using XFDelivery.Views;

namespace XFDelivery.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly DataService dataService;
        private readonly INavigationService navigationService;
        private List<ColoredTag> tags;
        private List<Item> items;
        private ColoredTag selectedTag;
        private List<Item> filteredItems;

        public MainPageViewModel(DataService dataService, INavigationService navigationService)
        {
            this.dataService = dataService;
            this.navigationService = navigationService;
        }

        protected override async Task LoadDataAsync()
        {
            var _tags = (await dataService.GetTagsAsync()).ToList();
            _tags.Add(new Tag() { id = 0, description = "ALL", image = "brigadeiro" });
            Tags = _tags.Select((o)=> new ColoredTag(o, Color.Transparent)).ToList();
            Items = await dataService.GetItemsAsync();
            SelectedTag = Tags[0];
        }
        private DelegateCommand<ColoredTag> _selectTagCommand;
        public DelegateCommand<ColoredTag> SelectTagCommand => _selectTagCommand ?? (_selectTagCommand = new DelegateCommand<ColoredTag>((tag) =>
        {
            SelectedTag = tag;
        }));
        private DelegateCommand<Item> _navigateToDetailPageCommand;
        public DelegateCommand<Item> NavigateToDetailPageCommand => _navigateToDetailPageCommand??( _navigateToDetailPageCommand = new DelegateCommand<Item>(async (model) =>
        {
            var navigationParams = new NavigationParameters
            {
                { "item", model }
            };
            await navigationService.NavigateAsync("Nav/DetailPage", navigationParams);
        }));
        public List<ColoredTag> Tags { get => tags; set => SetProperty(ref tags, value); }
        public List<Item> Items { get => items; set => SetProperty(ref items, value); }
        public List<Item> FilteredItems { get => filteredItems; 
            set => SetProperty(ref filteredItems, value); }
        public ColoredTag SelectedTag
        {
            get => selectedTag; set => SetProperty(ref selectedTag, value, () =>
                {
                    if (selectedTag.Id == 0)
                        FilteredItems = Items;
                    else
                        FilteredItems = Items.Where((item) => item.Tags.Split(',').Any((tag) => int.Parse(tag) == selectedTag.Id)).ToList();
                    Tags.ForEach(o => 
                    {
                        if (o == selectedTag)
                            o.Color = Color.Accent;
                        else
                            o.Color = Color.Default;
                    });
                });
        }
    }
    public class ColoredTag : INotifyPropertyChanged
    {
        private Color color;

        public event PropertyChangedEventHandler PropertyChanged;

        public ColoredTag(Tag tag, Color color)
        {
            Id = tag.id;
            Description = tag.description;
            Image = tag.image;
            this.color = color;
        }
        public int Id
        {
            get;
        }
        public string Description
        {
            get;
        }
        public string Image
        {
            get ;
        }
        public Color Color
        {
            get => color;
            set
            {
                color = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Color)));
            }
        }
    }
}
