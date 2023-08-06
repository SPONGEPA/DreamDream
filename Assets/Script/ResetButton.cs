using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script
{
    public class ResetButton : MonoBehaviour
    {
        /*private Transform spawn_hero;
        public Hero _hero;

        private void Awake()
        {
            spawn_hero = this.transform;
            //GameStartEvent.GameStartEvents += Create;
            GameStartEvent.GameStartEvents += OnClick;
        }

        private void Create()
        {
            Instantiate(_hero, spawn_hero);
        }*/

        public void OnClick()
        {
            //this.enabled = false;
            //gameObject.SetActive(false);
            SceneManager.LoadScene("StartScene");
        }
        
    }
}