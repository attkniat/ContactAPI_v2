namespace FuncContact_v2.UtilExtensions
{
    public  class Settings
    {
        public static string StorageStringConnection { get; set; }
        public static string APIUrlString { get; set; }

        public static void Load()
        {
            StorageStringConnection = SettingsHelper.GetStringConnQueueStorage();
            APIUrlString = SettingsHelper.GetAPIUrlString();
        }
    }
}