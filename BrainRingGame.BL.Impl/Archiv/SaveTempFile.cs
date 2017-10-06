using SharpCompress.Reader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainRingGame.BL.Impl.Archiv
{
   public class SaveTempFile
    {
        public void CreateDirectory(string locationArchiv, string name)
        {
            string tempPath = Path.GetTempPath();
            string pathArchiv = tempPath + name;

            using (Stream stream = File.OpenRead(locationArchiv))
            {
                IReader reader = ReaderFactory.Open(stream);

                while (reader.MoveToNextEntry())
                {
                    if (reader.Entry.IsDirectory)
                    {
                        Directory.CreateDirectory(pathArchiv + reader.Entry.FilePath);
                    }

                }
            }
            using (Stream stream = File.OpenRead(locationArchiv))
            {
                IReader reader = ReaderFactory.Open(stream);

                while (reader.MoveToNextEntry())
                {
                    if (!reader.Entry.IsDirectory)
                    {
                        File.Create(pathArchiv + reader.Entry.FilePath);
                    }
                }

            }
        }
    }
}
