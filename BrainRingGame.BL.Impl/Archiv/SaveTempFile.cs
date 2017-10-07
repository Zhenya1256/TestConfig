using BrainRingGame.Entity.Abstract.EntityHolders;
using SharpCompress.Reader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainRingGame.BL.Impl.Archiv
{
    public delegate void Mydelegate(string path);

    public class SaveTempFile
    {
        public   void CreateDirectory(string name)
        {
            string tempPath = Path.GetTempPath();
            string pathArchiv = tempPath + name;

            using (Stream stream = File.OpenRead(GameEntityHolder.PathToArchive))
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
            using (Stream stream = File.OpenRead(GameEntityHolder.PathToArchive))
            {
                IReader reader = ReaderFactory.Open(stream);

                while (reader.MoveToNextEntry())
                {
                    if (!reader.Entry.IsDirectory)
                    {
                        Mydelegate del= CreateFile;
                        IAsyncResult result;
                        string path = pathArchiv + reader.Entry.FilePath;
                        result = del.BeginInvoke(path, null, null);
                        del.EndInvoke(result);

                    }
                }
            }

            using (Stream stream = File.OpenRead(GameEntityHolder.PathToArchive))
            {
                IReader reader = ReaderFactory.Open(stream);

                while (reader.MoveToNextEntry())
                {
                    if (!reader.Entry.IsDirectory)
                    {
                        string path = pathArchiv + reader.Entry.FilePath;
                      //  MemoryStream streamFile = new MemoryStream();
                        reader.WriteEntryTo(path);

                      

                    }
                }
            }
        }

        private void CreateFile(string path)
        {
            File.Create(path);
        }

    }
}
