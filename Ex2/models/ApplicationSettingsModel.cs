using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2.models
{
    public class ApplicationSettingsModel : ISettingsModel
    {
        #region Singleton
        private static ISettingsModel m_Instance = null;
        public static ISettingsModel Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new ApplicationSettingsModel();
                }
                return m_Instance;
            }
        }
        #endregion
        public string FlightServerIP
        {
            get { return Setting.Default.FlightServerIP; }
            set { Setting.Default.FlightServerIP = value; }
        }
        public int FlightCommandPort
        {
            get { return Setting.Default.FlightCommandPort; }
            set { Setting.Default.FlightCommandPort = value; }
        }

        public int FlightInfoPort
        {
            get { return Setting.Default.FlightInfoPort; }
            set { Setting.Default.FlightInfoPort = value; }
        }

        public void SaveSettings()
        {
            Setting.Default.Save();
        }

        public void ReloadSettings()
        {
            Setting.Default.Reload();
        }

    }
}
