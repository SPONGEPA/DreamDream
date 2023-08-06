using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script
{
    public class IsReadyEvent : MonoBehaviour
    {
        public delegate void ReadyAction();

        public static int IsReadyNum;

        public static event ReadyAction IsReadyEvents;

        public static void Ready()
        {
            if (IsReadyEvents != null && IsReadyNum >= 2)
            {
                IsReadyEvents();
            }
        }

        private void Awake()
        {
            IsReadyNum = 0;
            IsReadyEvents += StartGame;
        }
        
        private async void StartGame()
        {
            //yield return new WaitForSeconds(3f);
            await Task.Delay(1000);
            SceneManager.LoadScene("GameScene");
        }
    }
}