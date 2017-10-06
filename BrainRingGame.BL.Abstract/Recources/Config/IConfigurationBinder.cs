using System;
using Bender.Configuration;

namespace BrainRingGame.BL.Abstract.Recources.Config
{
    public interface IConfigurationBinder
    {
        TEntity GetBinder<TEntity>();
        TEntity GetBinder<TEntity>(string name);
        TEntity GetBinder<TEntity>(string name, Action<DeserializerOptionsDsl> expresion, string configPath);
     }
}