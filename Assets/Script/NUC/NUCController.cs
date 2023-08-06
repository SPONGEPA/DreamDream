using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Script
{
    public class NUCController : MonoBehaviour
    {
        public  float sanMax;
        [SerializeField]
        private  float sanCurrent;
        public  float SanCurrent
        {
            get { return sanCurrent; }
            set
            {
                sanCurrent = value;
                if (SanCurrent > sanMax)
                {
                    //NUCFireEvent.Fire();
                    FireManager.NUCFire();
                    SanCurrent = 0;
                }
            }
        }

        public int favorMax;
        [SerializeField]
        private int favorCurrent;

        public int FavorCurrent
        {
            get { return favorCurrent; }
            set
            {
                favorCurrent = value;
                if (favorCurrent <= 0 || favorCurrent >= 100)
                {
                    GameOverEvent.GameOver(onTriggerObjects[0].gameObject);
                }
            }
        }
        private Rigidbody2D rbody;
        
        private List<Collider2D> onTriggerObjects = new List<Collider2D>();

        private void Awake()
        {
            SanCurrent = 0;
            favorMax = 100;
            FavorCurrent = 50;
            rbody = GetComponent<Rigidbody2D>();
            InvokeRepeating("SetFavor",0,1);
            InvokeRepeating("SetSan",0,Time.deltaTime);
        }

        private void Update()
        {
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.tag == "Player")
            {
                onTriggerObjects.Add(col);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                onTriggerObjects.Remove(other);
            }
        }

        private void SetSan()
        {
            if (onTriggerObjects.Count >= 2)
            {
                //SanCurrent++;
                SanCurrent = Mathf.Lerp(SanCurrent, SanCurrent+1, (float)Time.deltaTime);
            }
        }

        private void SetFavor()
        {
            if (onTriggerObjects.Count == 1)
            {
                switch (onTriggerObjects[0].GetComponent<Hero>().belong)
                {
                    case 1: FavorCurrent--;break;
                    case 2: FavorCurrent++;
                        break;
                }
            }
        }

        private void OnGameOver()
        {
            onTriggerObjects.Clear();
            //onTriggerObjects.Free();
        }
    }
}