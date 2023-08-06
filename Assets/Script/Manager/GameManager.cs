using UnityEngine;

namespace Script.Manager
{
    public class GameManager : IManager
    {
        
        
        private static GameManager m_Instance;
        public static GameManager Instance {
            get {
                if (m_Instance==null)
                {
                    m_Instance = new GameManager();
                }

                return m_Instance;
            }
        }

        public void Awake()
        {
            throw new System.NotImplementedException();
        }

        public void Start()
        {
            throw new System.NotImplementedException();
        }
        
        
        public void Init(Transform rootTrans, params object[] managers)
        {
            throw new System.NotImplementedException();
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