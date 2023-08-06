using System;
using UnityEngine;

namespace Script
{
    public class ShieldController : MonoBehaviour,IBelong
    {
        public int belong;
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.tag == "bullet")
            {
                if (col.GetComponent<IBelong>().GetBelong() != this.belong)
                {
                    //Debug.Log(col.GetComponent<Belong>().GetBelong());
                    Destroy(col.gameObject);
                }
            }
        }

        public int GetBelong()
        {
            return belong;
        }

        public void ChangeBelong(int newbelong)
        {
            belong = newbelong;
        }
    }
}