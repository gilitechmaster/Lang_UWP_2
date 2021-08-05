<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="Lang_UWP_2.Page2">
    
    <ContentPage.ToolbarItems>
        <ToolbarItem Text="+"
                     Clicked="OnNoteAddedClicked"/>
    </ContentPage.ToolbarItems>

    <ListView x:Name="리스트뷰"
              Margin="30"
              ItemSelected="OnListViewItemSelected">

        <ListView.ItemTemplate>
            <DataTemplate>
                <TextCell Text="{Binding Text}"
                          Detail="{Binding Date}"/>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
</ContentPage>
