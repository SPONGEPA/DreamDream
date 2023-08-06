using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Script.Manager;
//using Script.Samples;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public int speed;

    public List<Hero> players;

    private PlayerInput _playerInput;
    private Hero player;

    private Vector2 movementInput = Vector2.zero;
    private Vector2 aimInput = Vector2.zero;
    private bool fired = false;

    private bool facingRight = true;
    
    public delegate void PlayerFireDel();

    public PlayerFireDel FireDel;



    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        List<Hero> heros = new List<Hero>(FindObjectsOfType<Hero>());
        var index = _playerInput.playerIndex;
        player = heros.FirstOrDefault(m => m.GetBelong() - 1 == index);
        
        FireDel = () => player.gameObject.transform.GetChild(0).GetComponent<IFire>().Fire();
    }
    private void Update()
    {
        if (player != null)
        {
            Vector2 m = new Vector2(movementInput.x * speed, movementInput.y * speed) * Time.deltaTime;
            player.transform.Translate(m, Space.World);
        
            //判断是否需要翻面
            if (movementInput.x > 0 && !facingRight)
            {
                SetFacing(true);

            }else if (movementInput.x < 0 && facingRight)
            {
                SetFacing(false);
            }

            //设置武器朝向
            /*if (player.GetComponent<InputControlScheme>().GetType().Name == "Keyboard")
            {
                transform.right = (aimInput - new Vector2(transform.position.x, transform.position.y)).normalized;
            }
            else
            {*/
            player.transform.GetChild(0).right = aimInput.normalized;
            //}

            //执行武器发射功能
            if (fired)
            {
                if (FireDel != null)
                {
                    FireDel();
                }
            }
        }
    }

    public void onMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void onAim(InputAction.CallbackContext context)
    {
        aimInput = context.ReadValue<Vector2>();
    }

    public void onFire(InputAction.CallbackContext context)
    {
        fired = context.ReadValueAsButton();
        //fired = context.action.triggered;
        //fired = !fired;
    }
    
    
    void SetFacing(bool fr) // 让角色翻面
    {
        facingRight = fr;
        Vector3 ac = player.transform.localScale;
        if ((fr && ac.x < 0) || (!fr && ac.x > 0))//
        {
            ac.x *= -1;
        }
        player.transform.localScale = ac;

        Vector3 weapon = player.transform.Find("playerWeapon").localScale;
        weapon.x *= -1;
        player.transform.Find("playerWeapon").localScale = weapon;
    }
}
