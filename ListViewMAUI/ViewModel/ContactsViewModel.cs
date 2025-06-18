
using ListViewMAUI.Data;
using ListViewMAUI.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ListViewMAUI
{
    #region ContactsViewModel
    public class ContactsViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<Contacts>? contactsInfo;
        private SQLiteDatabase? database;
        private string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "contacts.db3");
        #endregion

        #region Properties
        public Contacts? Item { get; set; }
        public ObservableCollection<Contacts>? ContactsInfo
        {
            get
            {
                return contactsInfo;
            }
            set
            {
                contactsInfo = value;
                OnPropertyChanged("ContactsInfo");
            }
        }

        public SQLiteDatabase? Database
        {
            get
            {
                if (database == null)
                    database = new SQLiteDatabase(path);
                return database;
            }
        }

        public Command CreateContactsCommand { get; set; }
        public Command<object> EditContactsCommand { get; set; }
        public Command SaveItemCommand { get; set; }
        public Command DeleteItemCommand { get; set; }
        public Command AddItemCommand { get; set; }

        #endregion

        #region Constructor
        public ContactsViewModel()
        {
            CreateContactsCommand = new Command(OnCreateContacts);
            EditContactsCommand = new Command<object>(OnEditContacts);
            SaveItemCommand = new Command(OnSaveItem);
            DeleteItemCommand = new Command(OnDeleteItem);
            AddItemCommand = new Command(OnAddNewItem);
        }
        #endregion

        #region Methods
        private async void OnAddNewItem()
        {
            await this.Database!.AddContactAsync(Item!);
			await Shell.Current.Navigation.PopAsync();
		}

		private async void OnDeleteItem()
        {
            await this.Database!.DeleteContactAsync(Item!);
			await Shell.Current.Navigation.PopAsync();
		}

		private async void OnSaveItem()
        {
            await this.Database!.UpdateContactAsync(Item!);
			await Shell.Current.Navigation.PopAsync();
		}

        private void OnEditContacts(object obj)
        {
            Item = (Contacts)(obj as Syncfusion.Maui.ListView.ItemTappedEventArgs)!.DataItem;
            var editPage = new EditPage();
            editPage.BindingContext = this;
			Shell.Current.Navigation.PushAsync(editPage);
		}

        private void OnCreateContacts()
        {
            Item = new Contacts() { ContactName = "", ContactNumber="" } ;
            var editPage = new EditPage();
            editPage.BindingContext = this;
			Shell.Current.Navigation.PushAsync(editPage);
		}
        #endregion

        #region Interface Member

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
    #endregion
}
