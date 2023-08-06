using System;
using System.Collections.Generic;
using UnityEngine;
using Script.Manager;

namespace Script
{
    public class BulletTracking2 : BulletController
    {
        [SerializeField]
        private GameObject target;

        public float rotationAngle;

        public Vector2 direction;

        private void Awake()
        {
            rbody = GetComponent<Rigidbody2D>();
            SetBulletAttribute();
            GetTarget();
        }

        private void Update()
        {
            direction = target.transform.position - transform.position;
            float angle = 360 - Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angle);
            transform.rotation = transform.rotation * Quaternion.Euler(0, 0, rotationAngle);
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }

        private void GetTarget()
        {
            int targetBelong = belong == 0?3:2 / belong;
            //target = GameObject.FindWithTag("player");
            List<Hero> heros = new List<Hero>(FindObjectsOfType<Hero>());
            if (targetBelong != 3)
            {
                foreach (var hero in heros)
                {
                    if (hero.GetComponent<IBelong>().GetBelong() == targetBelong)
                    {
                        target = hero.gameObject;
                        break;
                    }
                }
            }
        }
    }
}