using System;

namespace FileMonitor
{
    public class Configuration
    {
        public string Folder { get; set; }
        public string SubFolder { get; set; }
        public string Icon { get; set; }
        public int Minutes_Yellow { get; set; }
        public int Minutes_Red { get; set; }
        public int Minutes_Refresh { get; set; }
        public DateTime LastUpdate { get; set; }
    }

    public static class ConfigutarionManager
    {
        static Configuration Config;
        private static string _path = @".\Config\";
        private static string _filename = "config.json";

        public static Configuration Instance()
        {
            if (Config == null)
            {
                Config = new Helpers.JsonFileHelper().LoadJson<Configuration>(_path, _filename);
            }

            return Config;
        }
        public static Configuration Save(Configuration _parametro)
        {
            if (_parametro != null)
            {
                new Helpers.JsonFileHelper().SaveJson(_path, _filename, _parametro);
                Config = null;
                Instance();
            }

            return Config;
        }
        public static Configuration Save()
        {
            new Helpers.JsonFileHelper().SaveJson(_path, _filename, Config);
            Config = null;
            Instance();

            return Config;
        }
    }
}
