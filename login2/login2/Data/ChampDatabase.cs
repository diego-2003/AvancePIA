using System;
using System.Collections.Generic;
using System.IO;
using SQLite;
using Xamarin.Essentials;
using System.Threading.Tasks;
using login2.Models;
using static login2.Services.ChampionJsonSerializacion;
using login2.Services;

public class Database
{
    private readonly SQLiteAsyncConnection _database;

    public Database()
    {
        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "champions.db3");
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<Champion>().Wait();
    }

    public Task<int> SaveChampionAsync(Champion champion)
    {
        return _database.InsertOrReplaceAsync(champion);
    }

    public Task<List<Champion>> GetChampionsAsync()
    {
        return _database.Table<Champion>().ToListAsync();
    }

    public async Task SaveChampionsToDatabase(string filePath)
    {
        var database = new Database();
        var jsonService = new ChampionJsonSerializacion();
        var champions = jsonService.LoadChampionsFromJson(filePath);

        foreach (var champion in champions)
        {
            await database.SaveChampionAsync(champion);
        }
    }
}
