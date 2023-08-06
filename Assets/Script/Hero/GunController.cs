using System;
using UnityEngine;

namespace Script
{
    public class GunController : MonoBehaviour
    {
        public Transform muzzlePos;
        public Transform shellPos;
        private Vector2 mousePos;
        private Vector2 direction;
        private float flipY;
        
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            muzzlePos = transform.Find("gunspwan");
            shellPos = transform.Find("gun_postion");
            flipY = transform.localScale.y;
        }

        private void Update()
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Shoot();
        }

        private void Shoot()
        {
            direction = (mousePos - new Vector2(transform.position.x, transform.position.y)).normalized;
            transform.right = direction;
        }
    }
}