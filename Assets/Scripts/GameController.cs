using System;
using System.Collections;
using System.Collections.Generic;
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

        void Update()
        {
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
        }

        private void StartGame() // Метод вызывающий процесс игры и который проверяет правильность нажатых клавиш
        {
            _random = Random.Range(0, 4);
            Debug.Log(_random);
            switch (_random)
            {
                case 1:
                    Up.gameObject.SetActive(true);
                    break;
                case 2:
                    Down.gameObject.SetActive(true);
                    break;
                case 3:
                    Left.gameObject.SetActive(true);
                    break;
                case 4:
                    Right.gameObject.SetActive(true);
                    break;
            }
        }

        public void timer()
        {
            
        }
        
    }
}
