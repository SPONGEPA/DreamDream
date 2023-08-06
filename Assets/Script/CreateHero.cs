using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class CreateHero : MonoBehaviour,IBelong
    {
        private Transform spawn_hero;
        public Hero _hero;
        public int belong;
        public GameObject healthBar;

        private void Awake()
        {
            //_hero = Resources.Load<Hero>("Prefabs/demon_spine");
            _hero = Resources.Load<Hero>("Player" + belong.ToString());
            spawn_hero = this.transform;
            //GameStartEvent.GameStartEvents += Create;
            Create();
        }

        private void Create()
        {
            //实例化玩家所选择的角色，并赋予角色正确的belong信息
            Hero hero = Instantiate(_hero, spawn_hero);
            hero.GetComponent<Hero>().belong = this.belong;
            hero.gameObject.SetActive(true);
            
            //显示玩家的武器，并让武器获取到应该发射的子弹
            hero.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            //hero.gameObject.transform.GetChild(0).gameObject.GetComponent<BaseFireController>().GetBullet();

            //让血条显示玩家血量
            healthBar.GetComponent<HealthBar>().player = hero;
            healthBar.GetComponent<HealthBar>().healthMax = hero.Health;
            healthBar.GetComponent<HealthBar>().healthCurrent = hero.Health;
            healthBar.transform.parent.gameObject.SetActive(true);

            healthBar.transform.parent.Find("head").GetChild(0).GetComponent<Image>().sprite =
                hero.transform.Find("playerImage").GetComponent<Image>().sprite;
            //InstallPlayerController();

            if (belong == 1)
            {
                HeroList.angle = hero.gameObject;
            }else if (belong == 2)
            {
                HeroList.demon = hero.gameObject;
            }
        }

        //public void InstallPlayerController()
        //{
        //    UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent(transform.GetChild(0).gameObject, "","PlayerController");
        //}
//
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