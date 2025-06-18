using SQLite;


namespace ListViewMAUI.Data
{
	#region SQLiteDatabase
	public class SQLiteDatabase
	{
		readonly SQLiteAsyncConnection _database;

		public SQLiteDatabase(string dbPath)
		{
			_database = new SQLiteAsyncConnection(dbPath);
			_database.CreateTableAsync<Contacts>().Wait();
		}

		public Task<List<Contacts>> GetContactsAsync()
		{
			return _database.Table<Contacts>().ToListAsync();
		}

		public Task<int> AddContactAsync(Contacts item)
		{
			return _database.InsertAsync(item);
		}

		public Task<int> DeleteContactAsync(Contacts item)
		{
			return _database.DeleteAsync(item);
		}

		public Task<int> UpdateContactAsync(Contacts item)
		{
			return _database.UpdateAsync(item);
		}
	}
	#endregion
}
