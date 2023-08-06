using Script.Manager;
using UnityEditor;
using UnityEngine;

namespace Script
{
    public class BaseFireController : MonoBehaviour, IBelong, IFire
    {
        public Transform shotSpawn;
        public GameObject bullet;
        public int belong;
        public float fireRate;
        public float nextFire;
        [SerializeField] public AudioClip shotSFX;
        void Update()
        {
            if (Input.GetButton("Fire1"))
            {
                Fire();
            }
        }

        public void OnEnable()
        {
            belong = transform.parent.gameObject.GetComponent<IBelong>().GetBelong();
            GetBullet();
            
        }

        public void Fire()
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                bullet.GetComponent<IBelong>().ChangeBelong(GetComponent<IBelong>().GetBelong());
                Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
                SoundEffectsPlayer.AudioSource.PlayOneShot(shotSFX);
            }
        }

#if UNITY_EDITOR
        public void GetBullet()
        {
            transform.Find("playerBullet").gameObject.SetActive(true);
            bullet = Resources.Load<GameObject>("Bullet" + GetComponent<IBelong>().GetBelong());
            PrefabUtility.SaveAsPrefabAsset(transform.Find("playerBullet").gameObject, "Assets/Resources/Bullet" + GetComponent<IBelong>().GetBelong() + ".prefab");
            AssetDatabase.SaveAssets();
            Destroy(transform.Find("playerBullet").gameObject);
        }
#endif

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