using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoDB.Bson;

namespace mongoNotes.DAL
{
    public class DAL
    {
        MongoServer server;


        public DAL()
        { }
        
        public DAL(string dbName)
        {
            this.MongoConnection(dbName);
        }
        
        public MongoDatabase MongoConnection(string dbName)
        {
            try
            {
                server = GetMongoConnection.GetConnection().GetServer();
                server.Connect();
                var db = server.GetDatabase(dbName);

                return db;
            }
            catch (System.TimeoutException tmex)
            {
                throw new TimeoutException(tmex.Message);
            }
            catch (MongoConnectionException monsex)
            {
                throw new MongoException(monsex.Message);
            }            
        }
    }
}