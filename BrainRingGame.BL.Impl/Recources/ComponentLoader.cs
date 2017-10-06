using BrainRingGame.BL.Abstract.Recources;
using BrainRingGame.BL.Impl.Archiv;
using BrainRingGame.Entity.Abstract.Common.Results;
using BrainRingGame.Entity.Abstract.Component;
using BrainRingGame.Entity.Abstract.Enums;
using BrainRingGame.Entity.Impl.Common.Results;
using BrainRingGame.Entity.Impl.Component;
using System.IO;

namespace BrainRingGame.BL.Impl.Recources
{
    public class ComponentLoader : IComponentLoader
    {
        public IDataResult<IStageComponent> GetComponent(DrawFileComponentType type)
        {
            ComponentReader reader = new ComponentReader();

            return reader.GetComponent(type);
        }

        public IResult ValidateComponent(DrawFileComponentType type)
        {
            ComponentValidator valid = new ComponentValidator();

            return valid.ValidateComponent(type);
        }

        

        public IDataResult<IStageComponent> GetRootWithChildInstance()
        {
            throw new System.NotImplementedException();
        }
    }
}