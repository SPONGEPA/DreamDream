using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;
using UnityEngine.Serialization;

public class BulletController : MonoBehaviour, IBelong
{
    public int damage;
    public int belong;
    public int ejectionnum;//可碰撞次数
    public float moveSpeed;
    public float size;
    [SerializeField] public AudioClip hitSFX;
    protected Rigidbody2D rbody;
    //private Vector3 movement; // 

    protected void Awake()
    {
        SetBulletAttribute();
        rbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rbody.velocity = transform.right * moveSpeed;
    }

    // Update is called once per frame

    protected void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == this.tag)
        {
            return;
        }else if (col.tag == "wall")
        {
            if (ejectionnum == 0)
            {
                Destroy(gameObject);
            }
            else
            {
                ejectionnum--;
                this.belong = 0;
                SetBulletAttribute();
                float colrotationz = col.transform.rotation.eulerAngles.z;
                transform.rotation = Quaternion.Euler(0,0,-transform.rotation.eulerAngles.z-180f+2*colrotationz);
                moveSpeed = -moveSpeed; 
                rbody.velocity = transform.right * moveSpeed;
            }
        }else if (col.tag == "Player")
        {
            if(this.belong != col.GetComponent<Hero>().belong)
            {
                Destroy(gameObject);
                col.GetComponent<Hero>().Hurt(damage);
                //col.GetComponent<Hero>().Health -= damage;
            }
        }
        /*else if(this.belong != col.GetComponent<Hero>().belong)
        {
            Destroy(gameObject);
            col.GetComponent<Hero>().Hurt(damage);
            //col.GetComponent<Hero>().Health -= damage;
        }*/
        //SoundEffectsPlayer.AudioSource.PlayOneShot(hitSFX);
    }

    protected void SetBulletAttribute()
    {
        //float Scale = (float)Math.Log(Math.E-0.2)*(ejectionnum+2)/10;
        float Scale = (float)0.1 + (float)ejectionnum*(float)0.03;
        GetComponent<Transform>().localScale = new Vector3(Scale,Scale,Scale);
        switch (belong)
        {
            case 0:GetComponent<SpriteRenderer>().color = Color.black;
                break;
            case 1:GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            case 2:GetComponent<SpriteRenderer>().color = Color.red;
                break;
        }
    }

    public int GetBelong()
    {
        return belong;
    }

    public void ChangeBelong(int newbelong)
    {
        belong = newbelong;
    }
}
