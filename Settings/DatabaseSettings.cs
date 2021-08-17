namespace BankManagementApi.Settings
{
    public class DatabaseSettings
    {
        public string User { get; set; }
        public string Password { get; set; }
        public string DatabaseConnectionString { 
            get{
                return $"mongodb+srv://{User}:{Password}@cluster0.kuabw.mongodb.net/BMS?authSource=admin&replicaSet=atlas-ysqw5c-shard-0&readPreference=primary&appname=mongodb-vscode%200.5.0&ssl=true";
            }
         }
    }
}