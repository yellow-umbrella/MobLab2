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
    public partial class FoundBooksPage : ContentPage
    {
        public FoundBooksPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            BookDatabase database = await BookDatabase.Instance;
            int curYear = DateTime.Now.Year;
            List<Book> books = await database.GetOlderItemsAsync(curYear - 10);
            foundBooks.ItemsSource = books;
            double p = (double)books.Count / (int)BindingContext * 100;
            Result.Text = "Found books are " + p.ToString() + "% of all books";
        }
    }
}