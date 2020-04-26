using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        public Image Up;
        public Image Down;
        public Image Left;
        public Image Right;
        public Text Numbers;
        public Text Title;

        private int _random;
        private float nextActionTime = 1f;
        private float period = 1f;

        public Text score;
        private int _score = 0;
        private float _gameTime;
        private int TimeLeft = -1;

        public float _vertical;
        public float _horizontal;

        private bool Miss;

        void Update()
        {
            _vertical = Input.GetAxis("Vertical");
            _horizontal = Input.GetAxis("Horizontal");
            if ((Time.time > nextActionTime) && (nextActionTime <= 3))
            {
                Numbers.text = nextActionTime.ToString();
                nextActionTime += period;
                if (Numbers.text == "3")
                {
                    Numbers.gameObject.SetActive(false);
                    Title.text = "GO!!!";
                    Title.transform.position = new Vector3(Title.transform.position.x + 1.85f,
                        Title.transform.position.y, Title.transform.position.z);
                    StartGame();
                }
            }

            if (TimeLeft > 0)
            {
                _gameTime += 1 * Time.deltaTime;
                if (_gameTime >= 1)
                {
                    TimeLeft -= 1;
                    _gameTime = 0;
                }

                switch (_random)
                {
                    case 1:
                        Up.gameObject.SetActive(true);
                        if (_vertical > 0)
                        {
                            _score += 200;
                            score.text = "Score: " + _score;
                            Up.gameObject.SetActive(false);
                            StartGame();
                        }
                        break;
                    case 2:
                        Down.gameObject.SetActive(true);
                        if (_vertical < 0)
                        {
                            _score += 200;
                            score.text = "Score: " + _score;
                            Down.gameObject.SetActive(false);
                            StartGame();
                        }
                        break;
                    case 3:
                        Right.gameObject.SetActive(true);
                        if (_horizontal > 0)
                        {
                            _score += 200;
                            score.text = "Score: " + _score;
                            Right.gameObject.SetActive(false);
                            StartGame();
                        }
                        break;
                    case 4:
                        Left.gameObject.SetActive(true);
                        if (_horizontal < 0)
                        {
                            _score += 200;
                            score.text = "Score: " + _score;
                            Left.gameObject.SetActive(false);
                            StartGame();
                        }
                        break;
                }
            }

            if (TimeLeft == 0)
            {
                Debug.Log("Loose");
            }
        }

        private void StartGame() // Метод вызывающий процесс игры и который проверяет правильность нажатых клавиш
        {
            _random = Random.Range(1, 5);
            TimeLeft = 2;
        }
        
    }
}