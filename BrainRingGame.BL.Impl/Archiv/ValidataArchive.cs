using BrainRingGame.Entity.Abstract.Common.Config;
using BrainRingGame.Entity.Abstract.Common.Results;
using BrainRingGame.Entity.Impl.Common.Results;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainRingGame.BL.Impl.Archiv
{
    public class ValidataArchive
    {
        private GameStageConfigSection configSection;

        public ValidataArchive(GameStageConfigSection configSection)
        {
            this.configSection = configSection;
        }

        public IResult Stage(string pathArchiv)
        {
            List<string> list = Directory.GetDirectories(pathArchiv).ToList();

            if (list.Count == configSection.StageCount)
            {
                return new Result
                {
                    Success = true
                };
            }

            return new Result
            {
                Success = false,
                Message = "Немає стейджів"

            };
        }

        public IResult SubStage(string pathArchiv)
        {
            List<string> stagesArchiv = Directory.GetDirectories
                (pathArchiv).ToList();

            Result result = new Result() { Success = true };

            foreach (var stage in configSection.StageItems)
            {
                List<string> substatages = new List<string>();

                if (stagesArchiv.Count >= stage.StageNumber)
                {
                    substatages = Directory.GetDirectories
                         (stagesArchiv[stage.StageNumber - 1]).ToList();
                }

                if (substatages.Count != stage.SubStageCount)
                {
                    //MessageHolder
                    result.Message += stage.StageNumber.ToString();
                    result.Success = false;
                }


            }

            return result;
        }

        public IResult SubStageItemTopics(string pathArchiv)
        {
            List<string> stagesArchiv = Directory.GetDirectories
                 (pathArchiv).ToList();
            Result result = new Result() { Success = true };

            foreach (var stage in configSection.StageItems)
            {
                List<string> substatages = new List<string>();

                if (stagesArchiv.Count >= stage.StageNumber)
                {
                    substatages = Directory.GetDirectories
                   (stagesArchiv[stage.StageNumber - 1]).ToList();
                }

                int i = 0;

                foreach (var subStage in stage.SubStageItems)
                {
                    List<string> topicThems = new List<string>();

                    if (substatages.Count - 1 >= i)
                    {
                        topicThems = Directory.GetDirectories
                        (substatages[i]).ToList();
                    }

                    if (topicThems.Count != subStage.TopicsCount)
                    {
                        //MessageHolder
                        result.Message += "substage";
                        result.Success = false;
                    }

                    i++;
                }
            }

            return result;
        }

        public IResult SubStageItemQuestion(string pathArchiv)
        {
            List<string> stagesArchiv = Directory.GetDirectories
                (pathArchiv).ToList();
            Result result = new Result() { Success = true };

            foreach (var stage in configSection.StageItems)
            {
                List<string> substatages = new List<string>();

                if (stagesArchiv.Count >= stage.StageNumber)
                {
                    substatages = Directory.GetDirectories
                   (stagesArchiv[stage.StageNumber - 1]).ToList();
                }
                int i = 0;

                foreach (var subStage in stage.SubStageItems)
                {
                    List<string> topicThems = new List<string>();
                    if (substatages.Count - 1 >= i)
                    {
                        topicThems = Directory.GetDirectories
                        (substatages[i]).ToList();
                    }

                    for (int k = 0; k < subStage.TopicsCount; k++)
                    {
                        List<string> questions = new List<string>();

                        if (topicThems.Count - 1 >= k)
                        {
                            questions = Directory.GetDirectories
                            (topicThems[k]).ToList();
                        }
                        //в кожній темі
                        if (questions.Count != subStage.TopicsCount)
                        {
                            //MessageHolder
                            result.Message += "substage";
                            result.Success = false;
                        }
                    }

                    i++;
                }
            }

            return result;
        }

        public IResult Question(string pathArchiv)
        {
            List<string> stagesArchiv = Directory.GetDirectories
               (pathArchiv).ToList();
            Result result = new Result() { Success = true };

            foreach (var stage in configSection.StageItems)
            {
                List<string> substatages = new List<string>();

                if (stagesArchiv.Count >= stage.StageNumber)
                {
                    substatages = Directory.GetDirectories
                   (stagesArchiv[stage.StageNumber - 1]).ToList();
                }

                int i = 0;

                foreach (var subStage in stage.SubStageItems)
                {
                    List<string> topicThems = new List<string>();

                    if (substatages.Count - 1 >= i)
                    {
                        topicThems = Directory.GetDirectories
                        (substatages[i]).ToList();
                    }

                    for (int k = 0; k < subStage.TopicsCount; k++)
                    {
                        List<string> questions = new List<string>();

                        if (topicThems.Count - 1 >= k)
                        {
                            questions = Directory.GetDirectories
                            (topicThems[k]).ToList();
                        }

                        foreach (var s in questions)
                        {
                            List<string> topicQuestion =
                                Directory.GetDirectories(s).ToList();

                            if (topicQuestion.Count == 0)
                            {
                                result.Success = false;
                                result.Message = "question";
                            }
                        }

                    }
                    i++;
                }
            }

            return result;

        }

        public IResult SubStageItemTopicsFile(string pathArchiv)
        {
            List<string> stagesArchiv = Directory.GetDirectories
              (pathArchiv).ToList();
            Result result = new Result() { Success = true };

            foreach (var stage in configSection.StageItems)
            {
                List<string> substatages = new List<string>();

                if (stagesArchiv.Count >= stage.StageNumber)
                {
                    substatages = Directory.GetDirectories
                   (stagesArchiv[stage.StageNumber - 1]).ToList();
                }

                int i = 0;

                foreach (var subStage in stage.SubStageItems)
                {
                    List<string> topicThems = new List<string>();

                    if (substatages.Count - 1 >= i)
                    {
                        topicThems = Directory.GetFiles
                        (substatages[i]).ToList();
                    }

                    if (topicThems.Count != 1)
                    {
                        //MessageHolder
                        result.Message += stage.StageNumber + " Sub " + (i + 1) + "  // ";
                        result.Success = false;
                    }

                    i++;
                }
            }

            return result;
        }

        public IResult SubStageItemQuestionFile(string pathArchiv)
        {
            List<string> stagesArchiv = Directory.GetDirectories
              (pathArchiv).ToList();
            Result result = new Result() { Success = true };

            foreach (var stage in configSection.StageItems)
            {
                List<string> substatages = new List<string>();

                if (stagesArchiv.Count >= stage.StageNumber)
                {
                    substatages = Directory.GetDirectories
                   (stagesArchiv[stage.StageNumber - 1]).ToList();
                }
                int i = 0;

                foreach (var subStage in stage.SubStageItems)
                {
                    List<string> topicThems = new List<string>();
                    if (substatages.Count - 1 >= i)
                    {
                        topicThems = Directory.GetDirectories
                        (substatages[i]).ToList();
                    }

                    for (int k = 0; k < subStage.TopicsCount; k++)
                    {
                        List<string> questions = new List<string>();

                        if (topicThems.Count - 1 >= k)
                        {
                            questions = Directory.GetFiles
                            (topicThems[k]).ToList();
                        }
                        //в кожній темі
                        if (questions.Count != 1)
                        {
                            //MessageHolder
                            result.Message += "substage";
                            result.Success = false;
                        }
                    }

                    i++;
                }
            }

            return result;
        }

        public IResult QuestionFile(string pathArchiv)
        {
            List<string> stagesArchiv = Directory.GetDirectories
            (pathArchiv).ToList();
            Result result = new Result() { Success = true };

            foreach (var stage in configSection.StageItems)
            {
                List<string> substatages = new List<string>();

                if (stagesArchiv.Count >= stage.StageNumber)
                {
                    substatages = Directory.GetDirectories
                   (stagesArchiv[stage.StageNumber - 1]).ToList();
                }

                int i = 0;

                foreach (var subStage in stage.SubStageItems)
                {
                    List<string> topicThems = new List<string>();

                    if (substatages.Count - 1 >= i)
                    {
                        topicThems = Directory.GetDirectories
                        (substatages[i]).ToList();
                    }

                    for (int k = 0; k < subStage.TopicsCount; k++)
                    {
                        List<string> questions = new List<string>();

                        if (topicThems.Count - 1 >= k)
                        {
                            questions = Directory.GetDirectories
                            (topicThems[k]).ToList();
                        }

                        foreach (var s in questions)
                        {
                            List<string> topicQuestion =
                                Directory.GetFiles(s).ToList();

                            if (topicQuestion.Count != 0)
                            {
                                result.Success = false;
                                result.Message = "question";
                            }
                        }

                    }
                    i++;
                }
            }

            return result;
        }

        public IResult QuestionItemFile(string pathArchiv)
        {
            List<string> stagesArchiv = Directory.GetDirectories
           (pathArchiv).ToList();
            Result result = new Result() { Success = true };

            foreach (var stage in configSection.StageItems)
            {
                List<string> substatages = new List<string>();

                if (stagesArchiv.Count >= stage.StageNumber)
                {
                    substatages = Directory.GetDirectories
                   (stagesArchiv[stage.StageNumber - 1]).ToList();
                }

                int i = 0;

                foreach (var subStage in stage.SubStageItems)
                {
                    List<string> topicThems = new List<string>();

                    if (substatages.Count - 1 >= i)
                    {
                        topicThems = Directory.GetDirectories
                        (substatages[i]).ToList();
                    }

                    for (int k = 0; k < subStage.TopicsCount; k++)
                    {
                        List<string> questions = new List<string>();

                        if (topicThems.Count - 1 >= k)
                        {
                            questions = Directory.GetDirectories
                            (topicThems[k]).ToList();
                        }

                        foreach (var s in questions)
                        {
                            List<string> topicQuestion =
                                Directory.GetDirectories(s).ToList();

                            List<string> files = Directory.GetFiles(topicQuestion[0]).ToList();

                            if (files.Count != 0)
                            {
                                result.Success = false;
                                result.Message = "question";
                            }

                        }

                    }

                    i++;
                }
            }

            return result;
        }

    }
}
