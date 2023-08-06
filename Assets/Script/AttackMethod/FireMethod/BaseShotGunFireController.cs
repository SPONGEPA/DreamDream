using System;
using Script.Manager;
using UnityEngine;

namespace Script
{
    public class BaseShotGunFireController : BaseFireController, IFire
    {
        public float fireAngle;
        public int bulletNum;
        private Quaternion preAngle;

        private void Awake()
        {
            preAngle = Quaternion.AngleAxis(fireAngle/bulletNum,Vector3.right);
        }

        void Update()
        {
            if (Input.GetButton("Fire1"))
            {
                Fire();
            }
        }
        
        public new void Fire()
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                for (int i = 0; i < bulletNum; i++)
                {
                    bullet.GetComponent<IBelong>().ChangeBelong(this.GetComponent<IBelong>().GetBelong());
                    GameObject newBullet = Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
                    newBullet.transform.eulerAngles +=
                        new Vector3(0, 0, fireAngle / (bulletNum - 1) * i - (fireAngle / 2));
                }
            }
        }
    }
}