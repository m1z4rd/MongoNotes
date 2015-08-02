using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoDB.Bson;

namespace mongoNotes.DAL
{
    /// <summary>
    /// Implementing Singleton in MongoClient Class
    /// </summary>
    internal class GetMongoConnection
    {
        private static MongoClient _instance;
        private static object syncLock = new object();

        public static MongoClient GetConnection()
        {
            if (_instance == null)
            {
                lock (syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new MongoClient();
                    }
                }
            }

            return _instance;
        }
    }
}