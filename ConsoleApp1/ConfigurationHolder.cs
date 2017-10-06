using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleConfig;

namespace MyConsoleTest
{
    public class ConfigurationHolder
    {
        private static GameTeamConfidSection _stageConfigSection;

        public static GameTeamConfidSection ApiConfiguration
        {
            get
            {
                if (_stageConfigSection == null)
                {

                    lock (typeof(ConfigurationHolder))
                    {
                        if (_stageConfigSection == null)
                        {
                            _stageConfigSection = Configuration.Load<GameTeamConfidSection>("GameTeamConfidSection");

                        }
                    }

                }
                return _stageConfigSection;

            }
        }
    }
}
