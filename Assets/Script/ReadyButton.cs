using Script.Manager;
#if UNITY_EDITOR
using UnityEditor;
#endif
#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif
using UnityEngine;
using UnityEngine.EventSystems;
using Vector3 = UnityEngine.Vector3;

namespace Script
{
    public class ReadyButton : MonoBehaviour,IIsSelect
    {
        public GameObject heroTable, weaponTabel, bulletTable;
        public GameObject currentHero, currentWeapon, currentBullet;
        public int belong; 
        public bool isSelected;
        [SerializeField] public AudioClip readySFX;
        public bool IsSelected
        {
            get { return isSelected;}
            set
            {
                isSelected = value; 
                
                enabled = isSelected;
                if (!isSelected)
                {
                    transform.localScale = Vector3.Lerp(Vector3.one, Vector3.one * (float)1.2, (float)0.1);
                }
                else
                {
                    transform.localScale = Vector3.Lerp(Vector3.one * (float)1.2, Vector3.one, (float)0.1);
                }
            }
        }
        
        public bool isReady;

        public bool IsReady
        {
            get { return isReady; }
            set
            {
                isReady = value;
                if (IsReady)
                {
                    IsReadyEvent.IsReadyNum++;
                    IsReadyEvent.Ready();
                    enabled = false;
                }
                else
                {
                    IsReadyEvent.IsReadyNum--;
                }
            }
        }

        private void Awake()
        {
            isReady = false;
        }

        private void Update()
        {
            switch (belong)
            {
                case 1: 
                    if (Input.GetKeyDown(KeyCode.J)) 
                    { 
                        Ready(); 
                    }
                    break;
                case 2:
                    if (Input.GetKeyDown(KeyCode.Keypad1)) 
                    { 
                        Ready(); 
                    }
                    break;
            }
        }

        public void Ready()
        {
            EventSystem.current.SetSelectedGameObject(null);
            CreatePrefab();
            IsReady = true;
            SoundEffectsPlayer.AudioSource.PlayOneShot(readySFX);
        }
#if UNITY_EDITOR
        private void CreatePrefab()
        {
            GameObject _Image = heroTable.transform.Find("Selection").transform.Find("Image").gameObject;//头像图片
            
            //将当前选择的角色、武器、子弹组合成为一个新的英雄(以及头像图片)
            currentHero = heroTable.GetComponent<TableManager>().currentItem;
            currentWeapon = weaponTabel.GetComponent<TableManager>().currentItem;
            currentBullet = bulletTable.GetComponent<TableManager>().currentItem;
            GameObject _hero = currentHero.transform.Find("hero").gameObject;
            GameObject _weapon = currentWeapon.transform.Find("weapon").gameObject;
            GameObject _bullet = currentBullet.transform.Find("bullet").gameObject;
            GameObject hero = Instantiate(_hero);
            GameObject weapon = Instantiate(_weapon);
            weapon.transform.name = "playerWeapon";
            GameObject bullet = Instantiate(_bullet);
            bullet.transform.name = "playerBullet";
            GameObject image = Instantiate(_Image);
            image.transform.name = "playerImage";
            bullet.transform.parent = weapon.transform;
            weapon.transform.parent = hero.transform;
            image.transform.parent = hero.transform;
            //await Ready.Delay(System.TimeSpan.FromSeconds(0.2));
            //yield return new WaitForSeconds(0.2f);
            
            //将组合生成的hero对象存入预制体player1中
            GameObject player = Resources.Load<GameObject>("Player" + belong);
            AssetDatabase.OpenAsset(player);
            var prefabStage = PrefabStageUtility.GetCurrentPrefabStage();
            PrefabUtility.SaveAsPrefabAsset(hero, prefabStage.prefabAssetPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.CloseCacheServerConnection();
            
            //销毁刚创建的一切
            Destroy(hero);
            Destroy(weapon);
            Destroy(bullet);
            Destroy(image);
        }
#endif
        //public int GetBelong()
        //{
        //    return belong;
        //}
//
        //public void ChangeBelong(int newbelong)
        //{
        //    belong = newbelong;
        //}

        public bool IsSelect()
        {
            return IsSelected;
        }

        public void ChangeSelected(bool t)
        {
            IsSelected = t;
        }
    }
}