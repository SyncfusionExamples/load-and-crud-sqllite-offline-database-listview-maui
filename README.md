# How to load the data from SQLite offline database in .NET MAUI ListView (SfListView)?
This demo explains about how to load the data from SQLite offline database in SfListView.

## Sample

```xaml
<syncfusion:SfListView
                x:Name="listView"
                ItemSize="60"
                ItemSpacing="5"
                TapCommand="{Binding EditContactsCommand}">
    <syncfusion:SfListView.ItemTemplate>
        <DataTemplate>
            <Grid x:Name="grid">
                <Grid.RowDefinitions>
                    <RowDefinition Height="*" />
                    <RowDefinition Height="1" />
                </Grid.RowDefinitions>
                <Grid
                    Padding="5,0,0,0"
                    RowSpacing="1"
                    VerticalOptions="Center">
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="50" />
                        <ColumnDefinition Width="*" />
                    </Grid.ColumnDefinitions>
                    <BoxView
                        BackgroundColor="{Binding Converter={StaticResource ColorConverter}}"
                        CornerRadius="25"
                        HeightRequest="50"
                        Opacity="0.7"
                        WidthRequest="50" />
                    <Label
                        HorizontalOptions="Center"
                        Text="{Binding ContactName, Converter={StaticResource TextConverter}}"
                        TextColor="White"
                        VerticalOptions="Center" />
                    <Grid
                        Grid.Column="1"
                        Padding="10,0,0,0"
                        RowDefinitions="*,*">
                        <Label
                            Grid.Row="0"
                            LineBreakMode="NoWrap"
                            Text="{Binding ContactName}"
                            TextColor="#474747" />
                        <Label
                            Grid.Row="1"
                            Grid.Column="0"
                            LineBreakMode="NoWrap"
                            Text="{Binding ContactNumber}"
                            TextColor="#474747" />
                    </Grid>
                </Grid>
                <BoxView Grid.Row="1" BackgroundColor="LightBlue" />
            </Grid>
        </DataTemplate>
    </syncfusion:SfListView.ItemTemplate>
</syncfusion:SfListView>
```

```c#
protected async override void OnAppearing()
{
    base.OnAppearing();
    listView.ItemsSource = await viewModel.Database!.GetContactsAsync();
}
```

## Requirements to run the demo

* [Visual Studio 2017](https://visualstudio.microsoft.com/downloads/) or [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/)
* Xamarin add-ons for Visual Studio (available via the Visual Studio installer).

## Troubleshooting

### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.
