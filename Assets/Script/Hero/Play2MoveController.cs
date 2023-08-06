using UnityEngine;

namespace Script
{
    public class Play2MoveController : MonoBehaviour
    {
        public float speed;
        private float h, v;
        private Rigidbody2D rbody;
        private Vector3 movement; // 
        private bool facingRight = true;
        // Start is called before the first frame update
        void Start()
        {
            rbody = GetComponent<Rigidbody2D>();
        }
        
        // Update is called once per frame
        void Update()
        {

            h = Input.GetAxis("Horizontal2");//
            v = Input.GetAxis("Vertical2");//
            
            //判断是否需要翻面
            /*if (h > 0 && !facingRight)
            {
                SetFacing(true);
            }else if (h < 0 && facingRight)
            {
                SetFacing(false);
            }*/
            facing();
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
        
        private void facing()
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float Angle = Mathf.Atan2(mousePosition.y - transform.position.y, mousePosition.x - transform.position.x) *
                          Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0,0,Angle));
        }
    }
}