﻿using Script.Manager;
using UnityEngine;

namespace Script
{
    public class GameStart : MonoBehaviour
    {
        
        private void Awake()
        {
            GameManager.Instance.Awake();
        }

        // Start is called before the first frame update
        void Start()
        {
            GameManager.Instance.Start();

        }

        // Update is called once per frame
        void Update()
        {
            GameManager.Instance.Update();

        }

        private void OnDestroy()
        {
            GameManager.Instance.Destroy();

        }
    }
}