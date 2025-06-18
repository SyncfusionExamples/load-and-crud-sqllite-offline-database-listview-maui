namespace ListViewMAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

		protected async override void OnAppearing()
		{
			base.OnAppearing();
			listView.ItemsSource = await viewModel.Database!.GetContactsAsync();
		}
	}

}
