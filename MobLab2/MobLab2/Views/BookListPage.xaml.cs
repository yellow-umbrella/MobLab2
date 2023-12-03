using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MobLab2.Data;
using MobLab2.Models;

namespace MobLab2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookListPage : ContentPage
    {
        BookDatabase database;
        List<Book> books;
        
        public BookListPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            database = await BookDatabase.Instance;
            books = await database.GetItemsAsync();
            listView.ItemsSource = books;
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BookPage
            {
                BindingContext = new Book()
            });
        }

        async void OnQueryMade(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FoundBooksPage
            {
                BindingContext = books.Count,
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new BookPage
                {
                    BindingContext = e.SelectedItem as Book
                });
            }
        }
    }
}