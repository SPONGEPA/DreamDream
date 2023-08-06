using System.Collections.Generic;
using Script.Manager;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

namespace Script
{
    public class TableManager : MonoBehaviour, IIsSelect
    {
        public GameObject table;
        [FormerlySerializedAs("isSelect")] public bool isSelected;
        public int belong;

        [SerializeField] public AudioClip SelectedSFX;

        public bool IsSelected
        {
            get { return isSelected;}
            set
            {
                isSelected = value; 
                LightEdge();
                enabled = isSelected;
            }
        }
        public GameObject currentItem;
        public List<GameObject> Items = new List<GameObject>();
        private int currentnum;

        private void Awake()
        {
            belong = transform.parent.gameObject.GetComponent<IBelong>().GetBelong();
            //table = this.gameObject;
            //关闭所有亮边
            IsSelected = false;
            transform.Find("IsSelect").gameObject.SetActive(IsSelected);
            
            //获取第一个选项
            currentItem = transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
            currentnum = 0;
            //currentItem.GetComponent<Image>().color = Color.black;
            currentItem.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.one * (float)1.5, (float)2*Time.deltaTime);
            GetChildren();
            this.enabled = false;
        }

        private void Update()
        {
            ItemSelect();
        }

        /*private void OnEnable()
        {
            LightEdge();
        }

        private void OnDisable()
        {
            LightEdge();
        }*/

        private void GetChildren()
        {
            for (int i = 0; i < transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.childCount; i++)
            {
                GameObject newItem = transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(i).gameObject;
                Items.Add(newItem);
            }
        }

        public void LightEdge()
        {
            //IsSelected = !IsSelected;
            transform.Find("IsSelect").gameObject.SetActive(IsSelected);
        }

        private void ItemSelect()
        {
            switch (belong)
            {
                case 1:
                    if (Input.GetKeyDown(KeyCode.A) && currentnum >= 1)
                    {
                        //currentItem.GetComponent<Image>().color = Color.white;
                        currentItem.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.one * (float)1.5, (float)Time.deltaTime);
                        currentnum--;
                        currentItem = Items[currentnum];
                        //currentItem.GetComponent<Image>().color = Color.black;
                        currentItem.transform.localScale = Vector3.Lerp(Vector3.one * (float)1.5, Vector3.one, (float)Time.deltaTime);
                        transform.Find("Selection").transform.Find("name").GetComponent<Text>().text =
                            currentItem.transform.Find("name").GetComponent<Text>().text;
                        transform.Find("Selection").transform.Find("introduction").GetComponent<Text>().text =
                            currentItem.transform.Find("introduction").GetComponent<Text>().text;
                        transform.Find("Selection").transform.Find("Image").GetComponent<Image>().sprite =
                            currentItem.transform.Find("Image").GetComponent<Image>().sprite;
                        SoundEffectsPlayer.AudioSource.PlayOneShot(SelectedSFX);
                    }else if (Input.GetKeyDown(KeyCode.D) && currentnum < Items.Count-1)
                    {
                        currentItem.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.one * (float)1.5, (float)Time.deltaTime);
                        //currentItem.GetComponent<Image>().color = Color.white;
                        currentnum++;
                        currentItem = Items[currentnum];
                        //currentItem.GetComponent<Image>().color = Color.black;
                        currentItem.transform.localScale = Vector3.Lerp(Vector3.one * (float)1.5, Vector3.one, (float)Time.deltaTime);
                        transform.Find("Selection").transform.Find("name").GetComponent<Text>().text =
                            currentItem.transform.Find("name").GetComponent<Text>().text;
                        transform.Find("Selection").transform.Find("introduction").GetComponent<Text>().text =
                            currentItem.transform.Find("introduction").GetComponent<Text>().text;
                        transform.Find("Selection").transform.Find("Image").GetComponent<Image>().sprite =
                            currentItem.transform.Find("Image").GetComponent<Image>().sprite;
                        SoundEffectsPlayer.AudioSource.PlayOneShot(SelectedSFX);
                    }
                    break;
                case 2:
                    if (Input.GetKeyDown(KeyCode.LeftArrow) && currentnum >= 1)
                    {
                        //currentItem.GetComponent<Image>().color = Color.white;
                        currentItem.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.one * (float)1.5, (float)Time.deltaTime);
                        currentnum--;
                        currentItem = Items[currentnum];
                        //currentItem.GetComponent<Image>().color = Color.black;
                        currentItem.transform.localScale = Vector3.Lerp(Vector3.one * (float)1.5, Vector3.one, (float)Time.deltaTime);
                        transform.Find("Selection").transform.Find("name").GetComponent<Text>().text =
                            currentItem.transform.Find("name").GetComponent<Text>().text;
                        transform.Find("Selection").transform.Find("introduction").GetComponent<Text>().text =
                            currentItem.transform.Find("introduction").GetComponent<Text>().text;
                        transform.Find("Selection").transform.Find("Image").GetComponent<Image>().sprite =
                            currentItem.transform.Find("Image").GetComponent<Image>().sprite;
                        SoundEffectsPlayer.AudioSource.PlayOneShot(SelectedSFX);
                    }else if (Input.GetKeyDown(KeyCode.RightArrow) && currentnum < Items.Count-1)
                    {
                        currentItem.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.one * (float)1.5, (float)Time.deltaTime);
                        //currentItem.GetComponent<Image>().color = Color.white;
                        currentnum++;
                        currentItem = Items[currentnum];
                        //currentItem.GetComponent<Image>().color = Color.black;
                        currentItem.transform.localScale = Vector3.Lerp(Vector3.one * (float)1.5, Vector3.one, (float)Time.deltaTime);
                        transform.Find("Selection").transform.Find("name").GetComponent<Text>().text =
                            currentItem.transform.Find("name").GetComponent<Text>().text;
                        transform.Find("Selection").transform.Find("introduction").GetComponent<Text>().text =
                            currentItem.transform.Find("introduction").GetComponent<Text>().text;
                        transform.Find("Selection").transform.Find("Image").GetComponent<Image>().sprite =
                            currentItem.transform.Find("Image").GetComponent<Image>().sprite;
                        SoundEffectsPlayer.AudioSource.PlayOneShot(SelectedSFX);
                    }
                    break;
            }
        }

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