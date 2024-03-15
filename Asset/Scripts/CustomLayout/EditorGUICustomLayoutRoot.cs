using System;
using Newtonsoft.Json;
using UnityEngine;

public class EditorGUICustomLayoutRoot : MonoBehaviour { }

namespace EditorGUICustomLayout
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

    public class UIBase
    {
        public float s_x
        {
            get { return rect.x; }
            set { rect.x = value; }
        }
        public float s_y
        {
            get { return rect.y; }
            set { rect.y = value; }
        }
        public float s_w
        {
            get { return rect.width; }
            set { rect.width = value; }
        }
        public float s_h
        {
            get { return rect.height; }
            set { rect.height = value; }
        }
        
        public int s_fontSize
        {
            get { return style.fontSize; }
            set { style.fontSize = value; }
        }
        public int s_alignment
        {
            get { return (int)style.alignment; }
            set { style.alignment = (TextAnchor)value; }
        }
        public int s_clipping
        {
            get { return (int)style.clipping; }
            set { style.clipping = (TextClipping)value; }
        }

        public string text;

        [JsonIgnore]
        public Rect rect;

        [JsonIgnore]
        public GUIStyle style = new();
    }

    [Serializable]
    public class Button : UIBase
    {
        
    }

    [Serializable]
    public class Text : UIBase
    {

    }

    [Serializable]
    public class Input : UIBase
    {
        
    }
}