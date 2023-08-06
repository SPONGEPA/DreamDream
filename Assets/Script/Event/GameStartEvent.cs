using System;
using Script.Manager;
using UnityEngine;

namespace Script
{
    public class GameStartEvent : MonoBehaviour
    {
        public delegate void GameStartAction();

        public static event GameStartAction GameStartEvents;

        public static void GameStart()
        {
            if (GameStartEvents != null)
            {
                GameStartEvents.Invoke();
            }
        }
    }
}