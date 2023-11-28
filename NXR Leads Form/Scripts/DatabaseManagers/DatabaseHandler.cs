using UnityEngine;
using SqlCipher4Unity3D;

//https://github.com/praeclarum/sqlite-net/wiki

namespace Nxr.FormLeads
{
    public class DatabaseHandler
    {

        private static string dbUri;
        public SQLiteConnection dbConnection;
        static public DatabaseHandler instance;
        public static bool isDatabaseLoaded = false;

        private DatabaseHandler(string databasePath)
        {
            Debug.Log(databasePath);
            dbConnection = new SQLiteConnection(databasePath, "130366");
        }

        public static DatabaseHandler GetInstance(string databasePath)
        {
            dbUri = Application.dataPath + databasePath;
            // Se ainda não houver uma instância, crie uma
            instance ??= new DatabaseHandler(dbUri);

            isDatabaseLoaded = instance != null;

            return instance;
        }

        public void Close()
        {
            dbConnection.Close();
        }

    }

}