using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDev.Persistence
{
    public class RecipeRepository
    {
        private SQLiteAsyncConnection connection;

        public RecipeRepository()
        {
            var connectionFactory = new ConnectionFactory();
            connection = connectionFactory.GetConnection();
        }

        public async Task Setup()
        {
            await connection.CreateTableAsync<Recipe>();
        }

        public async Task<List<Recipe>> List()
        {
            return await connection.Table<Recipe>().ToListAsync();
        }

        public async Task Insert(Recipe recipe)
        {
            await connection.InsertAsync(recipe);
        }

        public async Task InsertOrReplace(Recipe recipe)
        {
            await connection.InsertOrReplaceAsync(recipe);
        }

        public async Task Delete(Recipe recipe)
        {
            await connection.DeleteAsync(recipe);
        }

    }
}
