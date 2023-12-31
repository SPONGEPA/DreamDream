﻿using UnityEngine;

namespace Script
{
    public class test : MonoBehaviour
    {
        public class GetKeyValue : MonoBehaviour {

            public float speed = 10.0F;
            public float rotationSpeed = 100.0F;

            void Update()
            {
                detectPressedKeyOrButton();
            }

            public void detectPressedKeyOrButton()
            {
                foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(kcode))
                        Debug.Log("KeyCode down: " + kcode);
                }

            }
        }
    }
}