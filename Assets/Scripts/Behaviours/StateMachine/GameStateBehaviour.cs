using UnityEngine;

namespace Behaviours
{
    class GameStateBehaviour : MonoBehaviour
    {
        private GameStateController _gameStateController;

        private void OnEnable()
        {
            _gameStateController.Subscribe();
        }
        private void OnDisable()
        {
            _gameStateController.Unsubscribe();
        }

        private void Awake()
        {
            _gameStateController = new GameStateController();
        }
        private void Update()
        {
            _gameStateController.Update();
        }
        private void FixedUpdate()
        {
            _gameStateController.FixedUpdate();
        }
        private void LateUpdate()
        {
            _gameStateController.LateUpdate();
        }
    }
}
