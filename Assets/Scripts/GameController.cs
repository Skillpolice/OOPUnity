using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum PlayerType
{
    None = 0,
    Ball = 1,
    Cube = 2
}

namespace GeekBrains
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        public PlayerType _playerType = PlayerType.Ball;

        private CameraController _cameraController;
        private InputController _inputController;
        private ListExecudeObject _interactiveObject;
        private DisplayBonuses _displayBonuses;
        private DisplayEndGame _displayEndGame;
        private Reference _reference;

        private int _countBonuses;


        private void Awake()
        {


            _interactiveObject = new ListExecudeObject();

            _reference = new Reference();


            PlayerBase player = null;
            if (_playerType == PlayerType.Ball)
            {
                player = _reference.PlayerBall;
            }


            _cameraController = new CameraController(player.transform, _reference.MainCamera.transform);
            _interactiveObject.AddExecuteObject(_cameraController);

            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                _inputController = new InputController(player);
                _interactiveObject.AddExecuteObject(_inputController);
            }


            _displayBonuses = new DisplayBonuses(_reference.Bonuse);
            _displayEndGame = new DisplayEndGame(_reference.EndGame);
            foreach (var item in _interactiveObject)
            {
                if (item is BadBonus badBonus)
                {
                    badBonus.OnCaughtPlayerChange += CaughtPlayer;
                    badBonus.OnCaughtPlayerChange += _displayEndGame.GameOver;
                }

                if (item is GoodBonus goodBonus)
                {
                    goodBonus.OnPointChange += AddBonus;
                }
            }

            _reference.RestartButton.onClick.AddListener(RestartGame);
            _reference.RestartButton.gameObject.SetActive(false);

        }

        private void RestartGame()
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1f;
        }

        private void Update()
        {
            for (int i = 0; i < _interactiveObject.Length; i++)
            {
                var interactiveObject = _interactiveObject[i];

                if (interactiveObject == null)
                {
                    continue;
                }

                interactiveObject.Execute();
            }
        }


        private void AddBonus(int value)
        {
            _countBonuses += value;
            _displayBonuses.Display(_countBonuses);
        }


        private void CaughtPlayer(string value, Color args)
        {
            _reference.RestartButton.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }


        public void Dispose()
        {
            foreach (var item in _interactiveObject)
            {
                if (item is BadBonus badBonus)
                {
                    badBonus.OnCaughtPlayerChange -= CaughtPlayer;
                    badBonus.OnCaughtPlayerChange -= _displayEndGame.GameOver;
                }

                if (item is GoodBonus goodBonus)
                {
                    goodBonus.OnPointChange -= AddBonus;
                }
            }
        }

    }
}


