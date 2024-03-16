using UnityEditor;
using UnityEngine;
using EditorUGUI;

public class EditorUGUIWindow<T0> : EditorWindow where T0 : EditorPanelBase
{
    protected static T0 panel;

    private void Awake()
    {
        string name = typeof(T0).Name;
        GameObject obj = Instantiate(Resources.Load<GameObject>("Prefabs/Editor/" + name));
        obj.name = name;
        panel = obj.GetComponent<T0>();
        panel.Load();
    }
    private void OnDestroy() 
    {
        DestroyImmediate(panel.gameObject);    
    }    

    protected virtual void OnGUI()
    {
        DrawButton();
        DrawLabel();
        DrawTextField();
        DrawTexture();

        Repaint();
    }

    public void DrawLabel()
    {
        foreach (string key in panel.dicTxt.Keys)
        {
            GUI.Label(panel.dicTxt[key].rect, panel.dicTxt[key].text, panel.dicTxt[key].style);
        }
    }
    public void DrawTextField()
    {
        foreach (string key in panel.dicIpt.Keys)
        {
            panel.dicIpt[key].text = GUI.TextField(panel.dicIpt[key].rect, panel.dicIpt[key].text, panel.dicIpt[key].style);
        }
    }
    public void DrawButton()
    {
        foreach (string key in panel.dicBtn.Keys)
        {
            bool result = GUI.Button(panel.dicBtn[key].rect, panel.dicBtn[key].text, panel.dicBtn[key].style);

            BtnCallback(result, key);
        }
    }
    public void DrawTexture()
    {
        foreach (string key in panel.dicImg.Keys)
        {
            GUI.DrawTexture(panel.dicImg[key].rect, panel.dicImg[key].texture, panel.dicImg[key].scaleMode, panel.dicImg[key].alphaBlend, panel.dicImg[key].imgAspect);
        }
    }

    public virtual void BtnCallback(bool p_result, string p_btnName)
    {

    }
}
