using MauiAppMinhasCompras.Models;
using SQLite;

namespace MauiAppMinhasCompras.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDatabaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateIndexAsync<Produto>().Wait();
        }

        public Task<int> insert(Produto p) 
        {
            return _conn.InsertAsync(p);
        }

        public Task<List<Produto>> update(Produto p) 
        {
            string sql = "UPDATE Produto SET Descricao = ?, Quantidade = ?, Preco = ? WHERE Id = ?";

            return _conn.QueryAsync<Produto>(
                sql, p.Descricao, p.Quantidade, p.preço, p.Id
            );
        }
        
        public Task<int> Delete(int id) 
        {
            return _conn.Table<Produto>().DeleteAsync(i => i.id == id);
        }   
        
        public Task<List<Produto>> GetAll()
        {
            return _conn.Table<produto>().ToListAsync();
        }

        public Task<List<Produto>> Search(string q) 
        {
            string sql = "SELCT * Produto WHERE Descricao Like '%" + q + "%'";

            return _conn.QueryAsync<Produto>(sql);            );
        }

    }
}