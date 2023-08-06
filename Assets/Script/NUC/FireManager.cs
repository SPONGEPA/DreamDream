using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Script.FireMethods;
using UnityEngine;
using Random = System.Random;

namespace Script
{
    public class FireManager : MonoBehaviour
    {
        public static List<BaseFireMethod.FireAction> fireList = new List<BaseFireMethod.FireAction>();
        public static int fireDuration = 0;

        private void Awake()
        {
            fireDuration = 0;
            /*_fireList.Add(ShotGunFire.fireAction);
            _fireList.Add(ShotGunFire2.fireAction);*/
        }

        public static async void NUCFire()
        {
            ListRandom(fireList);
            foreach (BaseFireMethod.FireAction fireAction in fireList)
            {

                //Debug.Log("isFire");
                fireAction.Invoke();
                await Task.Delay(fireDuration);
            }
        }

        //将攻击列表进行乱序
        private static List<BaseFireMethod.FireAction> ListRandom(List<BaseFireMethod.FireAction> myList)
        {
 
            Random ran = new Random();            
            int index = 0;
            BaseFireMethod.FireAction temp = myList[0];
            for (int i = 0; i < myList.Count; i++)
            {
 
                index = ran.Next(0, myList.Count-1);
                if (index != i)
                {
                    temp = myList[i];
                    myList[i] = myList[index];
                    myList[index] = temp;
                }
            }
            return myList;
        }
    }
}