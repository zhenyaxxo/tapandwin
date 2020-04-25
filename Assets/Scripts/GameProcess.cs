using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    public class GameProcess: MonoBehaviour
    {
        public void StartGame()
        {
            
        }

        public int RandomKey()
        {
            return Random.Range(0, 4);
        }
    }
}