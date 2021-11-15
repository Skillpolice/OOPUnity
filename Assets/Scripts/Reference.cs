using UnityEngine;
using UnityEngine.UI;

namespace GeekBrains
{
    public class Reference
    {
        private PlayerBall _playerBall;
        private Camera _camera;
        private GameObject _bonuse;
        private GameObject _endGame;
        private Canvas _canvas;
        private Button _restartButton;

        public Button RestartButton
        {
            get
            {
                if (_restartButton == null)
                {
                    var gameObj = Resources.Load<Button>("UI/RestartButton");
                    _restartButton = Object.Instantiate(gameObj, Canvas.transform);
                }

                return _restartButton;
            }
        }

        public Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                {
                    _canvas = Object.FindObjectOfType<Canvas>();
                }

                return _canvas;
            }
        }


        public GameObject Bonuse
        {
            get
            {
                if (_bonuse == null)
                {
                    var gameObj = Resources.Load<GameObject>("UI/Bonuse");
                    _bonuse = Object.Instantiate(gameObj, Canvas.transform);
                }

                return _bonuse;
            }
        }

        public GameObject EndGame
        {
            get
            {
                if (_endGame == null)
                {
                    var gameObj = Resources.Load<GameObject>("UI/EndGame");
                    _endGame = Object.Instantiate(gameObj, Canvas.transform);
                }

                return _endGame;
            }
        }


        public PlayerBall PlayerBall
        {
            get
            {
                if (_playerBall == null)
                {
                    var gameObject = Resources.Load<PlayerBall>("Player");
                    _playerBall = Object.Instantiate(gameObject);
                }

                return _playerBall;
            }
        }

        public Camera MainCamera
        {
            get
            {
                if (_camera == null)
                {
                    _camera = Camera.main;
                }

                return _camera;
            }
        }
    }
}


