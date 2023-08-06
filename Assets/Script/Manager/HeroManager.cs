using UnityEngine;

namespace Script.Manager
{
    public class HeroManager : MonoBehaviour, IManager
    {

        private Hero m_Hero;
        private Transform m_SpawnHeroPosTrans;
        private bool m_IsPause;
        private bool m_IsGameOver;
        
        public bool IsGameOver => m_IsGameOver;
        
        
        public void Init(Transform rootTrans, params object[] managers)
        {
            LoadPrefab();
            m_SpawnHeroPosTrans = rootTrans.Find("spawn_hero");
            Instantiate(m_Hero, m_SpawnHeroPosTrans);

        }

        private void LoadPrefab()
        {
            m_Hero = Resources.Load<Hero>("Prefabs/demon_spine");
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }

        public void Destroy()
        {
            throw new System.NotImplementedException();
        }

        public void GameOver()
        {
            throw new System.NotImplementedException();
        }
    }
}