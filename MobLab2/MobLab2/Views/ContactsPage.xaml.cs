using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Runtime.InteropServices.ComTypes;
using System.Diagnostics;

namespace MobLab2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsPage : ContentPage
    {
        ObservableCollection<Contact> contactsCollect = new ObservableCollection<Contact>();
        
        public ContactsPage()
        {
            InitializeComponent();
        }

        void OnFindButtonClicked(object sender, EventArgs e)
        {
            FindContacts();
        }

        private async void FindContacts()
        {
            try
            {
                var contacts = await Contacts.GetAllAsync();
                contactsCollect.Clear();
                if (contacts == null)
                    return;

                foreach (var contact in contacts)
                {
                    if (contact.FamilyName.ToLower().EndsWith("ко")) 
                    {
                        contactsCollect.Add(contact);
                    }
                }           
                ContactsList.ItemsSource = contactsCollect;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}