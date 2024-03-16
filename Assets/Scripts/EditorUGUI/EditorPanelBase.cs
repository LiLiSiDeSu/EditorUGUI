using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorUGUI
{
    [Serializable]
    public class VisibleDic<T0, T1> 
    {
        public T0 key;
        public T1 value;

        public VisibleDic(T0 p_key, T1 p_value)
        {
            key = p_key;
            value = p_value;
        }
    }

    public class EditorPanelBase : MonoBehaviour
    {
        public List<VisibleDic<string, Button>> listVisibelDicBtn = new();
        public Dictionary<string, Button> dicBtn = new();

        public List<VisibleDic<string, Text>> listVisibelDicTxt = new();
        public Dictionary<string, Text> dicTxt = new();

        public List<VisibleDic<string, Input>> listVisibelDicIpt = new();
        public Dictionary<string, Input> dicIpt = new();
        
        public List<VisibleDic<string, Image>> listVisibelDicImg = new();
        public Dictionary<string, Image> dicImg = new();

        public void Load()
        {
            AddDicByList<Button>(listVisibelDicBtn, dicBtn);
            AddDicByList<Text>(listVisibelDicTxt, dicTxt);
            AddDicByList<Input>(listVisibelDicIpt, dicIpt);
            AddDicByList<Image>(listVisibelDicImg, dicImg);
        }
        public void AddDicByList<T0>(List<VisibleDic<string, T0>> p_list, Dictionary<string, T0> p_dic)
        {
            foreach (var item in p_list)
            {
                p_dic.Add(item.key, item.value);
            }
        }

        public void AddDic(string p_key, UIBase p_value)
        {
            if (p_value is Button)
            {
                Button value = p_value as Button;
                dicBtn.Add(p_key, value);
                listVisibelDicBtn.Add(new(p_key, value));
            }
            else if (p_value is Text)
            {
                Text value = p_value as Text;
                dicTxt.Add(p_key, value);
                listVisibelDicTxt.Add(new(p_key, value));
            }
            else if (p_value is Input)
            {
                Input value = p_value as Input;
                dicIpt.Add(p_key, value);
                listVisibelDicIpt.Add(new(p_key, value));
            }
        }
        public void RemoveDic(string p_key, UIBase p_value)
        {
            if (p_value is Button)
            {                
                dicBtn.Remove(p_key);

                for (int i = 0; i < listVisibelDicBtn.Count; i++)
                {
                    if (listVisibelDicBtn[i].value == p_value)
                    {
                        listVisibelDicBtn.RemoveAt(i);

                        break;
                    }
                }
            }
            else if (p_value is Text)
            {                
                dicTxt.Remove(p_key);
                for (int i = 0; i < listVisibelDicTxt.Count; i++)
                {
                    if (listVisibelDicTxt[i].value == p_value)
                    {
                        listVisibelDicTxt.RemoveAt(i);

                        break;
                    }
                }
            }
            else if (p_value is Input)
            {
                dicIpt.Remove(p_key);
                for (int i = 0; i < listVisibelDicIpt.Count; i++)
                {
                    if (listVisibelDicIpt[i].value == p_value)
                    {
                        listVisibelDicIpt.RemoveAt(i);

                        break;
                    }
                }
            }
        }
    }

    [CustomEditor(typeof(EditorPanelBase), true)]
    public class InspectorForBaseLayout : Editor
    {
        public EditorPanelBase self;

        private void Awake() 
        {
            self = target as EditorPanelBase;
        }

        public override void OnInspectorGUI()
        {   
            serializedObject.Update();

            if (GUILayout.Button("LoadControl"))
            {
                self.listVisibelDicBtn.Clear();
                self.listVisibelDicTxt.Clear();
                self.listVisibelDicIpt.Clear();
                self.listVisibelDicImg.Clear();
                self.dicBtn.Clear();
                self.dicTxt.Clear();
                self.dicIpt.Clear();
                self.dicImg.Clear();

                Button[] buttons = self.GetComponentsInChildren<Button>();
                foreach (var item in buttons)
                {
                    self.listVisibelDicBtn.Add(new(item.gameObject.name, item));
                }
                Text[] texts = self.GetComponentsInChildren<Text>();
                foreach (var item in texts)
                {
                    self.listVisibelDicTxt.Add(new(item.gameObject.name, item));
                }
                Input[] inputs = self.GetComponentsInChildren<Input>();
                foreach (var item in inputs)
                {
                    self.listVisibelDicIpt.Add(new(item.gameObject.name, item));
                }
                Image[] images = self.GetComponentsInChildren<Image>();
                foreach (var item in images)
                {
                    self.listVisibelDicImg.Add(new(item.gameObject.name, item));
                }

                self.Load();
            }

            serializedObject.ApplyModifiedProperties();

            base.OnInspectorGUI();
        }
    }
}