using BrainRingGame.BL.Abstract.Recources;
using BrainRingGame.BL.Impl.Archiv;
using BrainRingGame.Entity.Abstract.Common.Config;
using BrainRingGame.Entity.Abstract.Common.Results;
using BrainRingGame.Entity.Abstract.EntityHolders;
using BrainRingGame.Entity.Abstract.Enums;
using BrainRingGame.Entity.Impl.Common.Results;
using System.IO;

namespace BrainRingGame.BL.Impl.Recources
{
    public class ComponentValidator : IComponentValidator
    {
        public IResult ValidateComponent(DrawFileComponentType type)
        {
            //????
            string name = @"Game\";
            string tempPath = Path.GetTempPath();
            string path = tempPath + name;
            //????

            IResult result = new Result() { Success = true, Message="" };
            GameStageConfigSection entity = ConfigurationHolder.ApiConfiguration;
            ValidataArchive validataArchive = new ValidataArchive(entity);

            switch (type)
            {
                case DrawFileComponentType.Stage:
                    IResult resultStage = validataArchive.Stage(path);
                    result.Message = resultStage.Message;
                    break;
                case DrawFileComponentType.SubStage:
                    IResult resultSubFiles = 
                        validataArchive.SubStageFile(path);
                    result.Message = resultSubFiles.Message;

                    break;
                case DrawFileComponentType.Team:
                    IResult resultSubItemFiles =
                       validataArchive.QuestionFile(path);
                    result.Message = resultSubItemFiles.Message;
                    break;
                case DrawFileComponentType.Topic:
                    IResult resultQuestionFiles =
                       validataArchive.QuestionTopicFile(path);
                    result.Message = resultQuestionFiles.Message;
                    break;
            }

            return result;
        }
    }
}