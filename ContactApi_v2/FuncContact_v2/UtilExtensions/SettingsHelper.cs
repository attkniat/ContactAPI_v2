using System;

namespace FuncContact_v2.UtilExtensions
{
    public static class SettingsHelper
    {
        public const string APIUrlString = "APIUrlString";
        public const string StorageStringConnection = "StorageStringConnection";

        public static string GetStringConnQueueStorage() => Environment.GetEnvironmentVariable(StorageStringConnection);

        public static string GetAPIUrlString() => "https://contactapiv2.azurewebsites.net/";
    }
}