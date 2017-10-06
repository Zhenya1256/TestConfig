using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using BrainRingGame.Entity.Abstract.EntityHolders;

namespace BrainRingGame.Console.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var entity = ConfigurationHolder.ApiConfiguration;
            foreach (var s in entity.StageItems)
            {
                if (s.StageNumber == 1)
                {
                    System.Console.WriteLine(s.UploadConfiguration);
                    foreach (var t in s.SubStageItems)
                    {
                        System.Console.WriteLine(t.UploadTopicConfiguration.UploadConfigurationItems[0].UploadItemType);
                    }
                   
                }
            
            }

            System.Console.ReadKey();
        }
    }
}
