using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Script.Map
{
    public class SeaOfCockroaches : MonoBehaviour
    {
        public GameObject boss;
        public Cockroach cockroachPrefab;
        public float createRate;
        public float cockroachMoveSpeed;
        public int maxCockRoachNum;
        public int currentCockRoachNum;
        public GameObject cockRoachNumUI;

        private int CurrentCockRoachNum
        {
            get
            {
                return currentCockRoachNum;
            }
            set
            {
                currentCockRoachNum = value;
                cockRoachNumUI.GetComponent<NumOfCockroachesUI>().CurrentNum = value;
                if (currentCockRoachNum >= maxCockRoachNum)
                {
                    GameOverEvent.GameOver(HeroList.demon);
                }
            }
        }
        private List<Cockroach> cockroachesList = new List<Cockroach>();

        private void Awake()
        {
            //angel = transform.parent.gameObject.transform.Find("Player1(Clone)").gameObject;
            //demon = GameObject.Find("Player2(Clone)");
            CurrentCockRoachNum = 0;
            cockRoachNumUI.GetComponent<NumOfCockroachesUI>().CurrentNum = 0;
            cockRoachNumUI.GetComponent<NumOfCockroachesUI>().maxNum = maxCockRoachNum;
            //Instantiate(cockRoachNumUI);
            InvokeRepeating("CreateCockroach",0,createRate);
        }

        private void CreateCockroach()
        {
            cockroachPrefab.GetComponent<Cockroach>().boss = boss;
                //= new Cockroach(boss, cockroachMoveSpeed);
            cockroachPrefab.GetComponent<Cockroach>().moveSpeed = cockroachMoveSpeed;
            Instantiate(cockroachPrefab,new Vector3(Random.Range(-8,8),Random.Range(-4,4),0), Quaternion.Euler(Random.value,Random.value,0));
            CurrentCockRoachNum++;
        }

        private void WinningMethod()
        {
            
        }
    }
}