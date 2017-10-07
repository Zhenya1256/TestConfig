using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using BrainRingGame.Entity.Abstract.EntityHolders;
using BrainRingGame.BL.Impl.Archiv;
using System.IO;
using BrainRingGame.Entity.Impl.Common.Results;
using BrainRingGame.Entity.Abstract.Common.Results;
using BrainRingGame.Entity.Abstract.GameEntity;

namespace BrainRingGame.Console.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var entity = ConfigurationHolder.ApiConfiguration;
         
            //SaveTempFile temp = new SaveTempFile();
            string path = @"D:\game3.rar";
            string name = @"Game\";
            GameEntityHolder.PathToArchive = path;
            string tempPath = Path.GetTempPath();
       
           // temp.CreateDirectory(name);


            ValidataArchive w = new ValidataArchive(entity);
            BuildGame readA = new BuildGame(entity);
            readA.SubStageFile(tempPath + name);
            readA.QuestionTopicFile(tempPath + name);
            readA.QuestionFile(tempPath + name);

            foreach (IStage s in GameEntityHolder.Game.ChildItemss)
            {
                System.Console.WriteLine(s.StageNumber);
                foreach (var t in s.ChildItemss)
                {
                    System.Console.WriteLine("subs" + t.Image.Length);

                    foreach (var k in t.ChildItemss)
                    {
                        System.Console.WriteLine(new string('-', 5) + "questionTopic" + k.Image.Length);
                        // System.Console.WriteLine(new string('-', 5) + "questionTopic" + k.Text);

                        if (k.ChildItemss != null)
                        {
                            foreach (var q in k.ChildItemss)
                            {
                                if (q == null)
                                {
                                    break;
                                }
                                if (q.FileContent == null)
                                {
                                    string str = q.FilePath;
                                    break;
                                }
                                System.Console.WriteLine(new string('-', 30) + "question" + q.FileContent.Length);
                                // System.Console.WriteLine(new string('-', 30) + "question" + q.Text);
                            }
                        }
                    }
                }

            }

            //IResult res = w.SubStage(tempPath + name);
            //System.Console.WriteLine(res.Success.ToString());
            //System.Console.WriteLine(res.Message + "");
            //res = w.SubStageItemTopics(tempPath + name);
            //System.Console.WriteLine(res.Success.ToString());
            //System.Console.WriteLine(res.Message + "");
            //res = w.SubStageItemQuestion(tempPath + name);
            //System.Console.WriteLine(res.Success.ToString());
            //System.Console.WriteLine(res.Message + "");
            //res = w.Question(tempPath + name);
            //System.Console.WriteLine(res.Success.ToString());
            //System.Console.WriteLine(res.Message + "");

            //IResult res = w.SubStageFile(tempPath + name);
            //System.Console.WriteLine(res.Success.ToString());
            //System.Console.WriteLine(res.Message + "");

            //res = w.SubStageItemQuestionFile(tempPath + name);

            //System.Console.WriteLine(res.Success.ToString());
            //System.Console.WriteLine(res.Message + "");

            //res = w.QuestionFile(tempPath + name);

            //System.Console.WriteLine(res.Success.ToString());
            //System.Console.WriteLine(res.Message + "");

            //    Directory.Delete(tempPath + name);
            //  SubStageItemTopicsFile


            System.Console.ReadKey();
        }
    }
}
