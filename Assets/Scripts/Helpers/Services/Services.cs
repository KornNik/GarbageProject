using System;
using UnityEngine;
using Behaviours;
using Controllers;
using Data;

namespace Helpers
{
    sealed class Services
    {
        private static readonly Lazy<Services> _instance = new Lazy<Services>();

        public static Services Instance => _instance.Value;
        public Service<Camera> CameraService { get; private set; }
        public Service<AudioController> AudioController { get; private set; }
        public Service<SettingsController> SettingsController { get; private set; }
        public Service<TimeController> TimeController { get; private set; }
        public Service<DatasBundle> DatasBundle { get; private set; }
        public Service<LevelLoader> LevelLoader { get; private set; }
        public Service<PlayerLoader> PlayerLoader { get; private set; }
        public Service<GameStateBehaviour> GameStateBehavior { get; private set; }
        public Service<InputController> InputController { get; private set; }
        public PlayerService PlayerGameObject { get; private set; }

        public Services()
        {
            Initialize();
        }

        private void Initialize()
        {
            CameraService = new Service<Camera>();
            AudioController = new Service<AudioController>();
            SettingsController = new Service<SettingsController>();
            TimeController = new Service<TimeController>();
            DatasBundle = new Service<DatasBundle>();
            LevelLoader = new Service<LevelLoader>();
            PlayerLoader = new Service<PlayerLoader>();
            GameStateBehavior = new Service<GameStateBehaviour>();
            InputController = new Service<InputController>();
            PlayerGameObject = new PlayerService();
        }

    }
}
