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
        public float period = 1f;

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
                    Title.transform.position = new Vector3(Title.transform.position.x + 1.25f,
                        Title.transform.position.y, Title.transform.position.z);
                }
            }
        }
        
    }
}
