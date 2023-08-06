using System;
using Script.FireMethods;
using UnityEngine;

namespace Script
{
    public class ShotGunFire : BaseFireMethod
    {
        //public float duration = 5f;
        //public float fireRate = 0.2f;
        public Transform shotSpawn;
        //public GameObject bullet;
        public float fireAngle;
        public int bulletNum;

        public bool isFire = false;

        private float nextFire;
        private float offsetAngle = 0;
        //private bool isFire = false;

        private void Awake()
        {
            duration = 2f;
            fireRate = 0.2f;
            fireAction = new FireAction(Fire);
            NUCFireEvent.FireEvents += Fire;
            FireManager.fireList.Add(fireAction);
        }

        /*public override void Fire()
        {
            Debug.Log("is invoke");
            StartFire();
            isFire = true;
            
            Invoke("StopFire",duration);
        }*/

        public override void FireMethod()
        {
            for (int i = 0; i < bulletNum; i++)
            {
                bullet.GetComponent<BulletController>().belong = 0;
                GameObject newBullet = Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
                newBullet.transform.eulerAngles += new Vector3(0, 0, fireAngle / (bulletNum - 1) * i - (fireAngle / 2) + offsetAngle);
            }

            offsetAngle += 10;
        }
    }
}