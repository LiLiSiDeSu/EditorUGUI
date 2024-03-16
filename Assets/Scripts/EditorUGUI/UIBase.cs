using System;
using UnityEditor;
using UnityEngine;

namespace EditorUGUI
{
    [ExecuteAlways]
    public class UIBase : MonoBehaviour
    {
        public EditorPanelBase panel;

        public Rect rect = new(0, 0, 50, 20);

        protected virtual void Awake()
        {
            panel = GetComponentInParent<EditorPanelBase>();
        }
    }

    public class UIBaseHaveStyle : UIBase
    {
        public GUIStyle style;

        protected override void Awake()
        {
            base.Awake();

            style = new() { alignment = TextAnchor.UpperLeft, clipping = TextClipping.Clip, fontSize = 20 };
        }
    }
}