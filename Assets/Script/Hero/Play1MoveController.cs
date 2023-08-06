using UnityEngine;

namespace Script
{
    public class Play1MoveController : MonoBehaviour
    {
        public float speed;
        private float h, v;
        private Rigidbody2D rbody;
        private Vector3 movement; // 
        private bool facingRight = true;

        private Animator _animator;
        // Start is called before the first frame update
        void Start()
        {
            rbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }
        
        // Update is called once per frame
        void Update()
        {

            h = Input.GetAxis("Horizontal");//
            v = Input.GetAxis("Vertical");//
            
            Fire();
            
            //判断是否需要翻面
            if (h > 0 && !facingRight)
            {
                SetFacing(true);

            }else if (h < 0 && facingRight)
            {
                SetFacing(false);
            }
            //facing();
        }
        
        void SetFacing(bool fr) // 
        {
            facingRight = fr;
            Vector3 ac = transform.localScale;
            if ((fr && ac.x < 0) || (!fr && ac.x > 0))//
            {
                ac.x *= -1;
            }
            transform.localScale = ac;

            Vector3 weapon = transform.Find("playerWeapon").localScale;
            weapon.x *= -1;
            transform.Find("playerWeapon").localScale = weapon;
        }
        
        // 0.02s
        private void FixedUpdate()
        {
            movement = Vector3.zero;
            movement.x = h * speed;
            movement.y = v * speed;
            //movement.y = rigid.velocity.y;
            rbody.velocity = movement;
        }

        private void Fire()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                _animator.SetTrigger("fire");
            }else if (Input.GetButtonUp("Fire1"))
            {
                _animator.SetTrigger("idle");
            }

            if (Input.GetButtonDown("Fire2"))
            {
                _animator.SetTrigger("protect");
            }else if (Input.GetButtonUp("Fire2"))
            {
                _animator.SetTrigger("idle");
            }

            /*if (Input.GetButtonDown("Horizontal")||Input.GetButtonDown("Vertical"))
            {
                _animator.SetTrigger("fly");
            }else if (Input.GetButtonUp("Horizontal")||Input.GetButtonUp("Vertical"))
            {
                _animator.SetTrigger("idle");
            }*/
        }
        
        /*private void facing()
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float Angle = Mathf.Atan2(mousePosition.y - transform.position.y, mousePosition.x - transform.position.x) *
                          Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0,0,Angle));
        }*/
    }
}