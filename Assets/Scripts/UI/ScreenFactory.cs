using UnityEngine;
using Helpers;
using Helpers.Extensions;
using Data;

namespace UI
{
    sealed class ScreenFactory
    {
        private Canvas _canvas;
        private GameMenu _gameMenu;
        private MainMenu _mainMenu;
        private PauseMenu _pauseMenu;
        private LoadingScreen _loadingScreen;


        public ScreenFactory()
        {
            var resources = CustomResources.Load<Canvas>(Services.Instance.DatasBundle.ServicesObject.
                GetData<ResourcesPathData>().GetScreenPath(ScreenTypes.Canvas));
            _canvas = Object.Instantiate(resources, Vector3.one, Quaternion.identity);
        }

        public GameMenu GetGameMenu()
        {
            if (_gameMenu == null)
            {
                var resources = CustomResources.Load<GameMenu>(Services.Instance.DatasBundle.ServicesObject.
                    GetData<ResourcesPathData>().GetScreenPath(ScreenTypes.GameMenu));
                _gameMenu = Object.Instantiate(resources, _canvas.transform.position,
                    Quaternion.identity, _canvas.transform);
            }
            return _gameMenu;
        }

        public MainMenu GetMainMenu()
        {
            if (_mainMenu == null)
            {
                var resources = CustomResources.Load<MainMenu>(Services.Instance.DatasBundle.ServicesObject.
                    GetData<ResourcesPathData>().GetScreenPath(ScreenTypes.MainMenu));
                _mainMenu = Object.Instantiate(resources, _canvas.transform.position,
                    Quaternion.identity, _canvas.transform);
            }
            return _mainMenu;
        }
        public PauseMenu GetPauseMenu()
        {
            if (_pauseMenu == null)
            {
                var resources = CustomResources.Load<PauseMenu>(Services.Instance.DatasBundle.ServicesObject.
                    GetData<ResourcesPathData>().GetScreenPath(ScreenTypes.PauseMenu));
                _pauseMenu = Object.Instantiate(resources, _canvas.transform.position,
                    Quaternion.identity, _canvas.transform);
            }
            return _pauseMenu;
        }
        public LoadingScreen GetLoadingScreen()
        {
            if (_loadingScreen == null)
            {
                var resources = CustomResources.Load<LoadingScreen>(Services.Instance.DatasBundle.ServicesObject.
                    GetData<ResourcesPathData>().GetScreenPath(ScreenTypes.LoadingScreen));
                _loadingScreen = Object.Instantiate(resources, _canvas.transform.position,
                    Quaternion.identity, _canvas.transform);
            }
            return _loadingScreen;
        }
    }
}