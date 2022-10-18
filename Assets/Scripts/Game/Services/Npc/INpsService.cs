using System;
using TDS.Infrastructure;

namespace TDS.Game.Npc
{
    public interface INpsService : IService
    {

        event Action OnAllDead;
            
        void Init();
        void Dispose();
    }
}