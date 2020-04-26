using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
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
        public Image panel;
        
        private int _random;
        private float nextActionTime = 1f;
        private float period = 1f;
        
        private float _gameTime;
        private int TimeLeft = -1;
        public int TimeToStart = 3;

        public float _vertical;
        public float _horizontal;

        private int _score = 0;
        
        void Update()
        {
            _vertical = Input.GetAxis("Vertical");
            _horizontal = Input.GetAxis("Horizontal");
            
            if (TimeToStart >= 0)
            {
                _gameTime += 1 * Time.deltaTime;
                if (_gameTime >= 1)
                {
                    Debug.Log(TimeToStart);
                    Numbers.text = TimeToStart.ToString();
                    TimeToStart -= 1;
                    _gameTime = 0;
                }
            }

            if (TimeToStart == -1)
            {
                
                Numbers.gameObject.SetActive(false);
                Title.text = "GO!!!";
                Title.transform.position = new Vector3(Title.transform.position.x + 1.85f,
                    Title.transform.position.y, Title.transform.position.z);
                TimeToStart--; 
                StartGame();
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
                            addScore(200);
                            Up.gameObject.SetActive(false);
                            StartGame();
                        }
                        break;
                    case 2:
                        Down.gameObject.SetActive(true);
                        if (_vertical < 0)
                        {
                            addScore(200);
                            Down.gameObject.SetActive(false);
                            StartGame();
                        }
                        break;
                    case 3:
                        Right.gameObject.SetActive(true);
                        if (_horizontal > 0)
                        {
                            addScore(200);
                            Right.gameObject.SetActive(false);
                            StartGame();
                        }
                        break;
                    case 4:
                        Left.gameObject.SetActive(true);
                        if (_horizontal < 0)
                        {
                            addScore(200);
                            Left.gameObject.SetActive(false);
                            StartGame();
                        }
                        break;
                }
            }

            if (TimeLeft == 0)                        //Если закончилось время за которое нужно успеть нажать
            {
                panel.gameObject.SetActive(true);
                Up.gameObject.SetActive(false);
                Down.gameObject.SetActive(false);
                Left.gameObject.SetActive(false);
                Right.gameObject.SetActive(false);
                TimeLeft = -1;
            }
        }

        private void StartGame() // Метод вызывающий процесс игры и который проверяет правильность нажатых клавиш
        {
            _random = Random.Range(1, 5);
            TimeLeft = 2;
        }
        
        public void addScore(int HowManyScore)
        {
            var scoreTag = GameObject.FindGameObjectsWithTag("Score"); 
            _score += HowManyScore;
            var scoreText = scoreTag[0].GetComponents<Text>();
            scoreText[0].text = "Score: " + _score;
        }

        public void StartAgain()
        {
            panel.gameObject.SetActive(false);
            Numbers.gameObject.SetActive(true);
            _score = 0;
            Title.text = "Are you ready?";
            Title.transform.position = new Vector3(Title.transform.position.x - 1.85f,
                Title.transform.position.y, Title.transform.position.z);
            
            Numbers.text = "3";
            TimeToStart = 3;
        }
    }
}