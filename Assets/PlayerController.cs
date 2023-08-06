using System;
using Script.Manager;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Script
{
    public class PlayerController : MonoBehaviour
    {
        public float speed;

        public delegate void PlayerFireDel();

        public PlayerFireDel FireDel;
        
        private PlayerControls _controls;

        private Vector2 move;
        private Vector2 rotate;
        private Vector2 aimRotate;
        
        private bool facingRight = true;

        private void Awake()
        {
            speed = 10;
            _controls = new PlayerControls();

            _controls.GamePlay.move.performed += ctx => move = ctx.ReadValue<Vector2>();
            _controls.GamePlay.move.canceled += ctx => move = Vector2.zero;
            
            _controls.GamePlay.aim.performed += ctx => rotate = ctx.ReadValue<Vector2>();
            _controls.GamePlay.aim.canceled += ctx => rotate = Vector2.zero;

            _controls.GamePlay.fire.performed += ctx => Fire();
        }

        private void Update()
        {
            Vector2 m = new Vector2(move.x * speed, move.y * speed) * Time.deltaTime;
            transform.Translate(m, Space.World);

            //Vector2 r = new Vector3(rotate.x, rotate.y) * 100f * Time.deltaTime;
            //transform.GetChild(0).Rotate(r, Space.World);
            aimRotate = rotate.normalized;
            transform.GetChild(0).right = aimRotate;
            
            //判断是否需要翻面
            if (move.x > 0 && !facingRight)
            {
                SetFacing(true);

            }else if (move.x < 0 && facingRight)
            {
                SetFacing(false);
            }
        }

        private void OnEnable()
        {
            _controls.Enable();
            
            FireDel = () => transform.GetChild(0).GetComponent<IFire>().Fire();
        }

        private void OnDisable()
        {
            _controls.Disable();
        }

        void Fire()
        {
            //transform.GetChild(0).GetComponent<IFire>().Fire();
            if (FireDel != null)
            {
                FireDel();
            }
        }

        void SetFacing(bool fr) // 让角色翻面
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
    }
}