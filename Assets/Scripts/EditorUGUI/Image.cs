using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorUGUI
{
    [Serializable]
    public class Image : UIBase
    {
        public bool alphaBlend = true;
        public float imgAspect;
        public ScaleMode scaleMode;        
        public Texture texture;
    }
}
