namespace MauiApp2Net9
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void uxButton1_Clicked(object sender, EventArgs e)
        {
            uxCollectionView.ItemsSource = null;

            var items = new List<string>();
            items.Add($"Item 0");

            uxCollectionView.ItemsSource = items;
        }

        private void uxButton2_Clicked(object sender, EventArgs e)
        {
            uxCollectionView.ItemsSource = null;

            var items = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                items.Add($"Item {i}");
            }

            uxCollectionView.ItemsSource = items;
        }
    }

}
