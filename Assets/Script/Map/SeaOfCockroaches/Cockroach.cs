using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Script.Map
{
    public class Cockroach : MonoBehaviour
    {
        public GameObject boss;
        public float moveSpeed;
        
        [SerializeField] AudioClip dieSFX;
        [SerializeField] AudioClip cloneSFX;
        
        private Rigidbody2D rbody;
        private Vector2 direction;

        public Cockroach(GameObject newBoss, float speed)
        {
            this.boss = newBoss;
            moveSpeed = speed;
        }

        private void Awake()
        {
            rbody = gameObject.GetComponent<Rigidbody2D>();
            direction = boss.transform.position - transform.position;
            InvokeRepeating("Move",2,2);
        }

        private void Update()
        {
            //direction = boss.transform.position - transform.position;
            transform.right = Vector3.Slerp(transform.right, direction, (float)0.1);
            rbody.velocity = transform.right * moveSpeed;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.tag == "bullet" && col.GetComponent<IBelong>().GetBelong() != 0)
            {
                col.GetComponent<Collider2D>().enabled = false;
                switch (col.GetComponent<IBelong>().GetBelong())
                {
                    case 1:
                        Destroy(col.gameObject);
                        SoundEffectsPlayer.AudioSource.PlayOneShot(dieSFX);
                        Destroy(gameObject);
                        break;
                    case 2:Destroy(col.gameObject);
                        SoundEffectsPlayer.AudioSource.PlayOneShot(cloneSFX);
                        Instantiate(gameObject, transform.position + Random.onUnitSphere * 2, Quaternion.Euler(Random.value,Random.value,0));
                        break;
                }
                boss.GetComponent<NUCController>().SanCurrent++;
            }else if (col.tag == "wall")
            {
                Destroy(gameObject);
                SoundEffectsPlayer.AudioSource.PlayOneShot(dieSFX);
            }
        }
        

        private void Move()
        {
            direction = new Vector3(Random.Range(-8,8),Random.Range(-4,4),0);
            //transform.right = Vector3.Slerp(transform.right, new Vector3(Random.Range(-8,8),Random.Range(-4,4),0), (float)0.2);
            //rbody.velocity = transform.right * moveSpeed;
        }
    }
}