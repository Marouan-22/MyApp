using Firebase.Database;
using Firebase.Database.Query;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Repository
{
    public class TodoRepository : ITodoRepository<Todo>
    {
        private const string BaseUrl = "https://tasklist-test-f497f-default-rtdb.firebaseio.com/";

        private readonly ChildQuery _query;

        public TodoRepository()
        {
            string path = "items";
            _query = new FirebaseClient(BaseUrl).Child(path);
        }

        public async Task<bool> AddItemAsync(Todo item)
        {
            try
            {
                var addedItem = await _query
                    .PostAsync(item);
                item.Id = addedItem.Key;
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> UpdateItemAsync(Todo item)
        {
            try
            {
                Todo copy = new Todo() { Text = item.Text, Description = item.Description };
                await _query
                    .Child(item.Id)
                    .PutAsync(copy);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            try
            {
                await _query
                    .Child(id)
                    .DeleteAsync();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public async Task<Todo> GetItemAsync(string id)
        {
            try
            {
                var item = await _query
                    .Child(id)
                    .OnceSingleAsync<Todo>();
                item.Id = id;
                return item;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Todo>> GetItemsAsync(bool forceRefresh = false)
        {
            try
            {
                var firebaseObjects = await _query
                    .OnceAsync<Todo>();

                return firebaseObjects
                    .Select(x => new Todo { Id = x.Key, Text = x.Object.Text, Description = x.Object.Description });
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
