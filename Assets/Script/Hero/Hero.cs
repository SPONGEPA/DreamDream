using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;

public class Hero : MonoBehaviour,IBelong
{
    public int health;
    public int Health
    {
        get { return health;}
        set
        {
            health = value;
            if (health <= 0)
            {
                StopCoroutine(Die());
                StartCoroutine(Die());
            }
        }
    }
    public int belong;

    [SerializeField] AudioClip hitSPX;
    
    private bool isProtect;

    //private UnityEvent playerDieEvent = new UnityEvent();
    
    private Rigidbody2D rbody;

    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        isProtect = false;
        //playerDieEvent.AddListener(PlayerEvent.DieEvents);
    }

    // Update is called once per frame
    void Update()
    {
    }

    // 0.02s
    private void FixedUpdate()
    {
    }

    public void Hurt(int damage)
    {
        if (!isProtect)
        {
            Health -= damage;
        }
    }

    IEnumerator Protect()
    {
        _animator.SetTrigger("protect");
        isProtect = true;
        
        yield return new WaitForSeconds(2f);
        _animator.SetTrigger("idle");
        isProtect = false;
    }

    IEnumerator Die()
    {
        _animator.SetTrigger("die");

        //GetComponent<Play1MoveController>().enabled = false;

        GameOverEvent.GameOver(GetTarget());

        //transform.GetComponent<Material>().parent.SetFloat("Fade" , Mathf.Lerp(1,0,(float)0.1));
        
        yield return new WaitForSeconds(2f);

        //Animator.DestroyImmediate(_animator);
        PlayerEvent.Die();
        Destroy(gameObject);
    }
    
    private GameObject GetTarget()
    {
        GameObject target = null;
        int targetBelong = belong == 0?3:2 / belong;
        //target = GameObject.FindWithTag("player");
        List<Hero> heros = new List<Hero>(FindObjectsOfType<Hero>());
        if (targetBelong != 3)
        {
            foreach (var hero in heros)
            {
                if (hero.GetComponent<IBelong>().GetBelong() == targetBelong)
                {
                    target = hero.gameObject;
                    break;
                }
            }
        }

        return target;
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
