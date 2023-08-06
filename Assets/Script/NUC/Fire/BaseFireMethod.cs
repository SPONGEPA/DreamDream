using Script.Manager;
using UnityEngine;

namespace Script.FireMethods
{
    public abstract class BaseFireMethod : MonoBehaviour,IFire
    {
        //子类 不需要重写 此变量
        public delegate void FireAction();
        public static FireAction fireAction;
        
        //子类需要 重写 此变量
        public float duration;
        public float fireRate;
        public GameObject bullet;

        /*public BaseFireMethod(float a,float b, GameObject c)
        {
            this.duration = a;
            this.fireRate = b;
            bullet = c;
        }*/
        
        public void Fire()
        {
            FireManager.fireDuration = (int)duration * 1000;
            StartFire();
            
            Invoke("StopFire",duration);
            //Thread.Sleep((int)duration*1000);程序暂停函数

        }

        public abstract void FireMethod();

        public void StartFire()
        {
            InvokeRepeating("FireMethod",0,fireRate);
        }

        public void StopFire()
        {
            CancelInvoke("FireMethod");
        }
    }
}