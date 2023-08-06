using System;
using System.Collections.Generic;
using UnityEngine;
using Script.Manager;

namespace Script
{
    public class BulletTracking : BulletController
    {
        [SerializeField]
        private GameObject target;

        public float lerp;

        public Vector2 direction;

        private void Awake()
        {
            rbody = GetComponent<Rigidbody2D>();
            SetBulletAttribute();
            GetTarget();
        }

        private void Update()
        {
            if (target != null)
            {
                direction = target.transform.position - transform.position;
                transform.right = Vector3.Slerp(transform.right, direction, lerp);
                rbody.velocity = transform.right * moveSpeed;
            }
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