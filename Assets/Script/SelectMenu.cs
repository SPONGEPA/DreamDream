using System;
using System.Collections;
using System.Collections.Generic;
using Script.Manager;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace Script
{
    public class SelectMenu : MonoBehaviour,IBelong
    {
        private GameObject currentTable;
        private int currentnum;
        public List<GameObject> tables = new List<GameObject>();
        public int belong;
        [SerializeField] public AudioClip SelectedSFX;


        private void Awake()
        {
            //因为初始化的时候两个readybutton的awake各调用了一次isready导致isready把num多减了两次1，所以设置成2把他加回来
            GetChildren();
            FirstTableSelect();
        }

        private void Update()
        {
            switch (belong)
            {
                case 1:Player1TableSelect();
                    break;
                case 2:Player2TableSelect();
                    break;
            }
            
        }

        public void FirstTableSelect()
        {
            //EventSystem.current.SetSelectedGameObject(null);
            //EventSystem.current.SetSelectedGameObject(transform.GetChild(0).gameObject);
            currentnum = 0;
            currentTable = tables[currentnum];
            currentTable.GetComponent<TableManager>().IsSelected = true;
        }
        
        private void GetChildren()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject newTable = transform.GetChild(i).gameObject;
                tables.Add(newTable);
            }
        }
        
        private void Player2TableSelect()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && currentnum >= 1)
            {
                currentTable.GetComponent<IIsSelect>().ChangeSelected(false);
                currentnum--;
                currentTable = tables[currentnum];
                currentTable.GetComponent<IIsSelect>().ChangeSelected(true);
                SoundEffectsPlayer.AudioSource.PlayOneShot(SelectedSFX);
            }else if (Input.GetKeyDown(KeyCode.DownArrow) && currentnum < transform.childCount-1)
            {
                currentTable.GetComponent<IIsSelect>().ChangeSelected(false);
                currentnum++;
                currentTable = tables[currentnum];
                currentTable.GetComponent<IIsSelect>().ChangeSelected(true);
                SoundEffectsPlayer.AudioSource.PlayOneShot(SelectedSFX);
            }
        }
        
        private void Player1TableSelect()
        {
            if (Input.GetKeyDown(KeyCode.W) && currentnum >= 1)
            {
                currentTable.GetComponent<IIsSelect>().ChangeSelected(false);
                currentnum--;
                currentTable = tables[currentnum];
                currentTable.GetComponent<IIsSelect>().ChangeSelected(true);
                SoundEffectsPlayer.AudioSource.PlayOneShot(SelectedSFX);
            }else if (Input.GetKeyDown(KeyCode.S) && currentnum < transform.childCount-1)
            {
                currentTable.GetComponent<IIsSelect>().ChangeSelected(false);
                currentnum++;
                currentTable = tables[currentnum];
                currentTable.GetComponent<IIsSelect>().ChangeSelected(true);
                SoundEffectsPlayer.AudioSource.PlayOneShot(SelectedSFX);
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
}