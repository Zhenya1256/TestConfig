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

namespace BrainRingGame.Console.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var entity = ConfigurationHolder.ApiConfiguration;
         
            SaveTempFile temp = new SaveTempFile();
            string path = @"D:\game3.rar";
            string name = @"Game\";
            string tempPath = Path.GetTempPath();
       
           // temp.CreateDirectory(path,name);


            ValidataArchive w = new ValidataArchive(entity);
            //IResult res = w.SubStage(tempPath+name);
            //System.Console.WriteLine(res.Success.ToString() );
            //System.Console.WriteLine(res.Message +"");
            //res = w.SubStageItemTopics(tempPath + name);
            //System.Console.WriteLine(res.Success.ToString());
            //System.Console.WriteLine(res.Message + "");
            //res = w.SubStageItemQuestion(tempPath + name);
            //System.Console.WriteLine(res.Success.ToString());
            //System.Console.WriteLine(res.Message + "");
            //res = w.Question(tempPath + name);
            //System.Console.WriteLine(res.Success.ToString());
            //System.Console.WriteLine(res.Message + "");

            IResult res = w.SubStageItemTopicsFile(tempPath + name);
            System.Console.WriteLine(res.Success.ToString());
            //res= w.SubStageItemQuestionFile(tempPath + name);
            //System.Console.WriteLine(res.Success.ToString());
            //res = w.QuestionFile(tempPath + name);
            ////    Directory.Delete(tempPath + name);
        //    SubStageItemTopicsFile


            System.Console.ReadKey();
        }
    }
}
