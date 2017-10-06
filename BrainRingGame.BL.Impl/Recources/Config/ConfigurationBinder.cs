using System;
using Bender.Configuration;
using BrainRingGame.BL.Abstract.Recources.Config;
using SimpleConfig;

namespace BrainRingGame.BL.Impl.Recources.Config
{
    public class ConfigurationBinder : IConfigurationBinder
    {
        public TEntity GetBinder<TEntity>()
        {
            TEntity config = Configuration.Load<TEntity>();
            return config;
        }
        public TEntity GetBinder<TEntity>(string name)
        {
            TEntity config = Configuration.Load<TEntity>(name);
            return config;
        }
        public TEntity GetBinder<TEntity>(string name, Action<DeserializerOptionsDsl> expresion, string configPath)
        {
            TEntity config = Configuration.Load<TEntity>(name, expresion, configPath);
            return config;
        }
        //public TEntity GetBinder<TEntity>(BaseAddressEntity baseAddr)
        //{
        //    TEntity config = Configuration.Load<TEntity>(baseAddr.Name);
        //    return config;
        //}
    }
}