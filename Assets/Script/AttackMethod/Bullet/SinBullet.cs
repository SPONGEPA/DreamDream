using System;
using UnityEngine;

namespace Script
{
    public class SinBullet : BulletController
    {
        private float x = 0;

        private void Update()
        {
            x += 0.1f;  
            transform.Translate(transform.up * Mathf.Sin(x) * 0.1f);
        }
    }
}