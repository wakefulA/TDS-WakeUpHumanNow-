using TDS.Infrastructure.SceneLoader;
using UnityEngine;

namespace TDS.Infrastructure.StateMachine
{
    public class BootstrapeState : BaseState
    {
        public BootstrapeState(IGameStateMachine gameStateMachine) : base(gameStateMachine)
        {
        }
        
        
        public override void Enter()
        {
            Debug.Log($"In BootstrapState");

            RegisterAllGlobalServices();
            ISceneLoadService sceneLoadService = Services.Container.Get<ISceneLoadService>();
            sceneLoadService.Load("MenuScene", OnSceneLoaded);

        }

        private void OnSceneLoaded()
        {
            StateMachine.Enter<MenuState>();
        }

        public override void Exit()
        {

        }

       

        private void RegisterAllGlobalServices()
        {
            
            Services.Container.Register<ISceneLoadService>(new SyncSceneLoadService());

        }
    }
}