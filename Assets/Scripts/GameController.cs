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
        //Инициализация всего говна которое мне нужно(Знаю что пишется через большое кол-во классов, но я тупой)(ФИКСИ ЭТО АЛО ЕВГЕНИЙ)
        public Image Up;
        public Image Down;
        public Image Left;
        public Image Right;
        public Image panel;
        public Image ErrorAim;
        public Text Bonus;
        public Text Numbers;
        public Text Title;
        
        //Инициализация всех переменных
        private int _random;
        private float _gameTime;
        private int TimeLeft = -1;
        private int TimeToStart = 3;
        private int _score = 0;
        private int _bonus = 1;
        private int _howManyTrue = 0;
        private int _howManyFalse = 0;

        void Update()
        {
            if (TimeToStart >= 0)                            //Счетчик до начала игры 3... 2... 1...
            {
                _gameTime += 1 * Time.deltaTime;
                if (_gameTime >= 1)
                {
                    Numbers.text = TimeToStart.ToString();
                    TimeToStart -= 1;
                    _gameTime = 0;
                }
            }

            if (TimeToStart == -1)                          //Когда началась игра(инициализация всего чего надо)
            {
                
                Numbers.gameObject.SetActive(false);
                Title.text = "GO!!!";
                Title.transform.position = new Vector3(Title.transform.position.x + 1.85f,
                    Title.transform.position.y, Title.transform.position.z);
                TimeToStart--; 
                StartGame();
            }

            if (_howManyTrue == 3 && _bonus < 16)
            {
                _bonus *= 2;
                Bonus.text = "x" + _bonus;
                _howManyTrue = 0;
            }

            if (_howManyFalse == 2 && _bonus >= 1)
            {
                _bonus /= 2;
                Bonus.text = "x" + _bonus;
                _howManyFalse = 0;
            }

            if (_bonus == 0)
            {
                panel.gameObject.SetActive(true);
                Up.gameObject.SetActive(false);
                Down.gameObject.SetActive(false);
                Left.gameObject.SetActive(false);
                Right.gameObject.SetActive(false);
                TimeLeft = -1;
            }
            if (TimeLeft > 0)                         //Таймер (2 секунды) за которое нужно что то нажать
            {
                _gameTime += 1 * Time.deltaTime;
                if (_gameTime >= 1)
                {
                    TimeLeft -= 1;
                    _gameTime = 0;
                }

                switch (_random)                                        //проверка на правильность нажатия клавиш...(я знаю что полное дерьмо, надо будет фиксить)
                {
                    case 1:
                        Up.gameObject.SetActive(true);                    //как же меня бесит то что я пишу в одном файле...но мне так удобно(ФИКСИ)
                        if (Input.GetKeyDown("up"))
                        {                                                 //В общем, тут суть в том что берется рандом и проверяется если нажато то что нужно,
                            
                            addScore(200);                                //тогда все окей, если что то не то нажато то гг
                            Up.gameObject.SetActive(false);
                            ErrorAim.gameObject.SetActive(false);
                            _howManyTrue += 1;
                            _howManyFalse = 0;
                            StartGame();
                        }
                        if (Input.GetKeyDown("down"))
                        {
                            _howManyFalse += 1;
                            _howManyTrue = 0;
                            TimeLeft = 0;
                        }
                        if (Input.GetKeyDown("left"))
                        {
                            _howManyFalse += 1;
                            _howManyTrue = 0;
                            TimeLeft = 0;
                        }
                        if (Input.GetKeyDown("right"))
                        {
                            _howManyFalse += 1;
                            _howManyTrue = 0;
                            TimeLeft = 0;
                        }
                        break;
                    case 2:
                        Down.gameObject.SetActive(true);
                        if (Input.GetKeyDown("down"))
                        {
                            addScore(200);
                            Down.gameObject.SetActive(false);
                            ErrorAim.gameObject.SetActive(false);
                            _howManyTrue += 1;
                            _howManyFalse = 0;
                            StartGame();
                        }
                        if (Input.GetKeyDown("up"))
                        {
                            _howManyFalse += 1;
                            _howManyTrue = 0;
                            TimeLeft = 0;
                        }
                        if (Input.GetKeyDown("left"))
                        {
                            _howManyFalse += 1;
                            _howManyTrue = 0;
                            TimeLeft = 0;
                        }
                        if (Input.GetKeyDown("right"))
                        {
                            _howManyFalse += 1;
                            _howManyTrue = 0;
                            TimeLeft = 0;
                        }
                        break;
                    case 3:
                        Right.gameObject.SetActive(true);
                        if (Input.GetKeyDown("right"))
                        {
                            addScore(200);
                            Right.gameObject.SetActive(false);
                            ErrorAim.gameObject.SetActive(false);
                            _howManyTrue += 1;
                            _howManyFalse = 0;
                            StartGame();
                        }
                        if (Input.GetKeyDown("down"))
                        {
                            _howManyFalse += 1;
                            _howManyTrue = 0;
                            TimeLeft = 0;
                        }
                        if (Input.GetKeyDown("left"))
                        {
                            _howManyFalse += 1;
                            _howManyTrue = 0;
                            TimeLeft = 0;
                        }
                        if (Input.GetKeyDown("up"))
                        {
                            _howManyFalse += 1;
                            _howManyTrue = 0;
                            TimeLeft = 0;
                        }
                        break;
                    case 4:
                        Left.gameObject.SetActive(true);
                        if (Input.GetKeyDown("left"))
                        {
                            addScore(200);
                            Left.gameObject.SetActive(false);
                            ErrorAim.gameObject.SetActive(false);
                            _howManyTrue += 1;
                            _howManyFalse = 0;
                            StartGame();
                        }
                        if (Input.GetKeyDown("down"))
                        {
                            _howManyFalse += 1;
                            _howManyTrue = 0;
                            TimeLeft = 0;
                        }
                        if (Input.GetKeyDown("up"))
                        {
                            _howManyFalse += 1;
                            _howManyTrue = 0;
                            TimeLeft = 0;
                        }
                        if (Input.GetKeyDown("right"))
                        {
                            _howManyFalse += 1;
                            _howManyTrue = 0;
                            TimeLeft = 0;
                        }
                        break;
                }
            }                                         //<----------- здесь конец проверки

            if (TimeLeft == 0)                        //Если закончилось время за которое нужно успеть нажать
            {
                _howManyFalse += 1;
                _howManyTrue = 0;
                ErrorAim.gameObject.SetActive(true);
                Up.gameObject.SetActive(false);
                Down.gameObject.SetActive(false);
                Left.gameObject.SetActive(false);
                Right.gameObject.SetActive(false);
                StartGame();
                
            }
        }

        private void StartGame() // Метод вызывающий процесс игры и который проверяет правильность нажатых клавиш
        {
            _random = Random.Range(1, 5);
            TimeLeft = 2;
        }
        
        public void addScore(int HowManyScore) //Для мультипликатора написал метод в который можно указать сколько очков добавить
        {
            var scoreTag = GameObject.FindGameObjectsWithTag("Score"); 
            _score += HowManyScore;
            var scoreText = scoreTag[0].GetComponents<Text>();
            scoreText[0].text = "Score: " + _score;
        }

        public void StartAgain() // Инициализация если игрок начал заново
        {
            _bonus = 1;
            Bonus.text = "x" + _bonus;
            ErrorAim.gameObject.SetActive(false);
            panel.gameObject.SetActive(false);
            Numbers.gameObject.SetActive(true);
            _score = 0;
            addScore(0);
            Title.text = "Are you ready?";
            Title.transform.position = new Vector3(Title.transform.position.x - 1.85f,
                Title.transform.position.y, Title.transform.position.z);
            
            Numbers.text = "3";
            TimeToStart = 3;
        }
    }
}