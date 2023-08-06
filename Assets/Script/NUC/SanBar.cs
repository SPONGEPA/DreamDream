using System;
using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class SanBar : MonoBehaviour
    {
        public GameObject NUC;
        private Image sanBar;
        public float sanMax;
        private float sanCurrent;
        
        public float SanCurrent
        {
            get { return sanCurrent; }
            set
            {
                sanCurrent = value;
            }
        }

        private void Awake()
        {
            sanBar = GetComponent<Image>();
            SanCurrent = NUC.GetComponent<NUCController>().SanCurrent;
            sanMax = NUC.GetComponent<NUCController>().sanMax;
        }

        private void FixedUpdate()
        {
            SanCurrent = NUC.GetComponent<NUCController>().SanCurrent;
            if (SanCurrent <= 0)
            {
                sanBar.fillAmount = 0;
            }
            else
            {
                sanBar.fillAmount = (float)Mathf.Lerp(sanBar.fillAmount,SanCurrent / (float)sanMax, (float)2*Time.deltaTime);
            }
            //sanBar.GetComponent<Image>().color = new Color(1,sanBar.fillAmount,sanBar.fillAmount,1);
        }
    }
}