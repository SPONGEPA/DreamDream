using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Script
{
    public class FavorBar : MonoBehaviour
    {
        public GameObject NUC;
        private Image favorBar;
        public int favorMax;
        [SerializeField]
        private int favorCurrent;
        
        public int FavorCurrent
        {
            get { return favorCurrent; }
            set
            {
                favorCurrent = value;
            }
        }

        private void Start()
        {
            favorBar = GetComponent<Image>();
            FavorCurrent = NUC.GetComponent<NUCController>().FavorCurrent;
            favorMax = NUC.GetComponent<NUCController>().favorMax;
        }

        private void Update()
        {
            FavorCurrent = NUC.GetComponent<NUCController>().FavorCurrent;
            if (FavorCurrent <= 0)
            {
                favorBar.fillAmount = 0;
            }
            else
            {
                favorBar.fillAmount = Mathf.Lerp(favorBar.fillAmount,(float)FavorCurrent / (float)favorMax, (float)(1/Time.deltaTime));
            }
            //favorBar.GetComponent<Image>().color = new Color(1,favorBar.fillAmount,favorBar.fillAmount,1);
        }
    }
}