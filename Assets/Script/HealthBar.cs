using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class HealthBar : MonoBehaviour
    {
        public Hero player;
        public Text healthTxt;
        public int healthCurrent;

        public int healthMax;

        private Image healthBar;
        // Start is called before the first frame update
        void Start()
        {
            healthBar = GetComponent<Image>();
            //healthMax = player.GetComponent<Hero>().Health;
            //healthCurrent = player.GetComponent<Hero>().Health;
            PlayerEvent.DieEvents += WhenPlayerDie;
        }

        // Update is called once per frame
        void Update()
        {
            if (player == null)
            {
                return;
            }
            healthCurrent = player.GetComponent<Hero>().Health;
            if (healthCurrent <= 0)
            {
                healthBar.fillAmount = 0;
            }
            else
            {
                healthBar.fillAmount = (float)healthCurrent / (float)healthMax;
            }
            healthBar.GetComponent<Image>().color = new Color(1,healthBar.fillAmount,healthBar.fillAmount,1);
        }

        private void WhenPlayerDie()
        {
            this.transform.parent.gameObject.SetActive(false);
            this.enabled = false;
        }
    }
}