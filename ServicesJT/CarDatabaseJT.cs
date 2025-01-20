﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using EvaluacionP3JT.ModelsJT;


namespace EvaluacionP3JT.ServicesJT
{
    public class CarDatabaseJT
    {
        private readonly SQLiteAsyncConnection _database;

        public CarDatabaseJT(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<CarsJT>().Wait();
        }

        public Task<int> SaveCarAsync(CarsJT car)
        {
            return _database.InsertAsync(car);
        }

        public Task<List<CarsJT>> GetCarsAsync()
        {
            return _database.Table<CarsJT>().ToListAsync();
        }
    }
}
