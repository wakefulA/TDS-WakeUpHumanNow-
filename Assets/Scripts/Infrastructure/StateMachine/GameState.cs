﻿using System;
using JetBrains.Annotations;
using TDS.Game.InputService;
using TDS.Game.Player;
using TDS.Infrastructure.SceneLoader;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TDS.Infrastructure.StateMachine
{
    public class GameState : BaseState
    {
        public GameState(IGameStateMachine gameStateMachine) : base(gameStateMachine)
        {
        }

        public override void Enter()
        {
            //TODO: Show loading screen
            ISceneLoadService sceneLoadService = Services.Container.Get<ISceneLoadService>();
            sceneLoadService.Load("GameScene", OnSceneLoaded);
        }
        

        public override void Exit()
        {
            UnRegisterLocalServices();
        }

        private void UnRegisterLocalServices()
        {
            Services.Container.UnRegister<IInputService>();
        }

        private void OnSceneLoaded()
        {
            //TODO: Init all local services
            RegisterLocalServices();
            
            //TODO: Hide loading screen
        }

        private void RegisterLocalServices()
        {
            PlayerMovement playerMovement = Object.FindObjectOfType<PlayerMovement>();
            RegisterInputService(playerMovement);
            InitPlayerMovement(playerMovement);
        }

        private static void RegisterInputService([NotNull] PlayerMovement playerMovement)
        {
            
            Services.Container.Register<IInputService>(new StandaloneInputService(Camera.main, 
                playerMovement.transform));
        }

        private void InitPlayerMovement(PlayerMovement playerMovement)
        {
           playerMovement.Construct(Services.Container.Get<IInputService>());
        }
    }
}