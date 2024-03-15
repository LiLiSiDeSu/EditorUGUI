using System.Collections.Generic;
using System.IO;
using EditorGUICustomLayout;
using UnityEditor;
using UnityEngine;

public class BaseCustomLayoutConfig
{
    public Dictionary<string, Button> dicBtn = new();
    public Dictionary<string, Text> dicTxt = new();
    public Dictionary<string, EditorGUICustomLayout.Input> dicIpt = new();

    public BaseCustomLayoutConfig() { }
    public BaseCustomLayoutConfig(Dictionary<string, Button> p_dicBtn, Dictionary<string, Text> p_dicTxt, 
                                  Dictionary<string, EditorGUICustomLayout.Input> p_dicIpt)
    {
        dicBtn = p_dicBtn;
        dicTxt = p_dicTxt;
        dicIpt = p_dicIpt;
    }
}

[ExecuteAlways]
public class BaseCustomLayout : MonoBehaviour
{
    public string PathSave;

    public List<VisibleDic<string, Button>> listVisibelDicBtn = new();
    public Dictionary<string, Button> dicBtn = new();

    public List<VisibleDic<string, Text>> listVisibelDicTxt = new();
    public Dictionary<string, Text> dicTxt = new();

    public List<VisibleDic<string, EditorGUICustomLayout.Input>> listVisibelDicIpt = new();
    public Dictionary<string, EditorGUICustomLayout.Input> dicIpt = new();

    protected virtual void Awake() 
    {
        PathSave = Application.dataPath + "/Scripts/mama/Other/BaseFrameWork/Tools/" + gameObject.name + "Config.json";        
    }

    public void InitProperties(Dictionary<string, Button> p_dicBtn, Dictionary<string, Text> p_dicTxt, Dictionary<string, EditorGUICustomLayout.Input> p_dicIpt)
    {        
        dicBtn = p_dicBtn;
        dicTxt = p_dicTxt;
        dicIpt = p_dicIpt;

        if (File.Exists(PathSave))
        {
            BaseCustomLayoutConfig config = MgrJson.Load<BaseCustomLayoutConfig>(PathSave);
            
            dicBtn = config.dicBtn;
            dicTxt = config.dicTxt;
            dicIpt = config.dicIpt;
        }

        foreach (string key in dicBtn.Keys)
        {
            listVisibelDicBtn.Add(new VisibleDic<string, Button>(key, dicBtn[key]));
        }
        foreach (string key in dicTxt.Keys)
        {
            listVisibelDicTxt.Add(new VisibleDic<string, Text>(key, dicTxt[key]));
        }
        foreach (string key in dicIpt.Keys)
        {
            listVisibelDicIpt.Add(new VisibleDic<string, EditorGUICustomLayout.Input>(key, dicIpt[key]));
        }
    }

    public void Save()
    {
        BaseCustomLayoutConfig config = new(dicBtn, dicTxt, dicIpt);

        MgrJson.Save(config, PathSave);
    }
}

[CustomEditor(typeof(BaseCustomLayout), true)]
public class InspectorForBaseLayout : Editor
{
    public override void OnInspectorGUI()
    {   
        serializedObject.Update();

        if (GUILayout.Button("SaveConfig"))
        {
            (target as BaseCustomLayout).Save();
        }    

        serializedObject.ApplyModifiedProperties();

        base.OnInspectorGUI();
    }
}
