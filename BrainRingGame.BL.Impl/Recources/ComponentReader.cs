using BrainRingGame.BL.Abstract.Recources;
using BrainRingGame.Entity.Abstract.Common.Results;
using BrainRingGame.Entity.Abstract.Component;
using BrainRingGame.Entity.Abstract.Enums;
using BrainRingGame.Entity.Impl.Common.Results;

namespace BrainRingGame.BL.Impl.Recources
{
    public class ComponentReader :  IComponentReader
    {
        public IDataResult<IStageComponent> GetComponent(DrawFileComponentType type)
        {
            ComponentValidator componentValidator = new ComponentValidator();
            IResult result = componentValidator.ValidateComponent(type);
            IDataResult<IStageComponent> dataResult = 
                result as IDataResult<IStageComponent>;

            if (result.Success)
            {

                switch (type)
                {
                    case DrawFileComponentType.Stage:
                        break;
                    case DrawFileComponentType.SubStage:


                        break;
                    case DrawFileComponentType.Team:
                        break;
                    case DrawFileComponentType.Topic:
                        break;
                }
            }


            //DataResult<IStageComponent> dataResult = new DataResult<IStageComponent>();
            //IStageComponent stage = new StageComponent();
            //IFileData fileData = new FileData();
            //fileData.CurrentComponent = new MemoryStream();

            //stage.CurrentComponentFileData = fileData;


            //dataResult.Data = stage;

            return dataResult;
        }
    }
}