using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace СollatzРypothesisApp
{
    static class Utils
    {
        public static string SettingKeyRead(string key)
        {
            string result = string.Empty;
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                result = appSettings[key] ?? string.Empty;
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
                //todo
            }
            return result;
        }

        public static bool SettingKeyReWrite(string key, string value)
        {
            //"C:\\Users\\User_2019\\source\\repos\\CollatzGypothesis\\СollatzРypothesisApp\\bin\\Debug\\netcoreapp3.1\\СollatzРypothesisApp.dll.config"
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;

                if (settings[key] == null)
                    settings.Add(key, value);
                else
                    settings[key].Value = value;

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
                return false;
            }
            return true;
        }
    }
}
