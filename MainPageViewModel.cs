using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MauiApp2Net9
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand LoadOneItemCommand { get; }

        public ICommand LoadManyItemsCommand { get; }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainPageViewModel()
        {
            LoadOneItemCommand = new Command(async () => await LoadOneItem());

            LoadManyItemsCommand = new Command(async () => await LoadManyItems());
        }

        private async Task LoadManyItems()
        {
            IsBusy = true;

            Items = [];

            await Task.Delay(2000);

            for (int i = 0; i < 5; i++)
            {
                var item = new PlatformOption
                {
                    Name = $"item {i}"
                };

                Items.Add(item);
            }

            IsBusy = false;
        }

        private async Task LoadOneItem()
        {
            await LoadInitialItems();
        }

        public async Task Init()
        {
            await LoadInitialItems();
        }

        private async Task LoadInitialItems()
        {
            IsBusy = true;

            Items = [];

            await Task.Delay(2000);

            var item = new PlatformOption
            {
                Name = "item1"
            };
            Items.Add(item);

            IsBusy = false;
        }

        private PlatformOptionCollection _items = [];

        public PlatformOptionCollection Items
        {
            get => _items;
            set
            {
                if (_items != value)
                {
                    _items = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _isBusy;

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    OnPropertyChanged();
                }
            }
        }
    }

    public class PlatformOption
    {
        public string Name { get; set; }
    }

    public class PlatformOptionCollection : ObservableCollection<PlatformOption>
    {
        public PlatformOptionCollection()
        {

        }

        public PlatformOptionCollection(IEnumerable<PlatformOption> collection) : base(collection)
        {

        }
    }
}
