using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using MobLab2.Models;

namespace MobLab2.Data
{
    public class BookDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<BookDatabase> Instance = new AsyncLazy<BookDatabase>(async () =>
        {
            var instance = new BookDatabase();
            CreateTableResult result = await Database.CreateTableAsync<Book>();
            return instance;
        });

        public BookDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<Book>> GetItemsAsync()
        {
            return Database.Table<Book>().ToListAsync();
        }

        public Task<List<Book>> GetOlderItemsAsync(int year)
        {
            return Database.QueryAsync<Book>(
                "SELECT * FROM [Book] WHERE [Year] <=" + year.ToString());
        }

        public Task<Book> GetItemAsync(int id)
        {
            return Database.Table<Book>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Book item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Book item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
