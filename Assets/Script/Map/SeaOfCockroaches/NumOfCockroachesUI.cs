using System;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Map
{
    public class NumOfCockroachesUI : MonoBehaviour
    {
        public GameObject currentNumUI;
        public GameObject maxNumUI;
        [SerializeField] public int maxNum;
        [SerializeField] private int currentNum;

        public int CurrentNum
        {
            get
            {
                return currentNum;
            }
            set
            {
                currentNum = value;
                currentNumUI.GetComponent<Text>().text = currentNum.ToString();
            }
        }

        private void Awake()
        {
            currentNumUI = transform.Find("CurrentNum").gameObject;
            maxNumUI = transform.Find("MaxNum").gameObject;
            CurrentNum = 0;
        }
    }
}