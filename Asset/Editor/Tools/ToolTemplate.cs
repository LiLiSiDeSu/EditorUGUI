using UnityEditor;
using UnityEngine;

public class ToolTemplate : BaseCustomEditorGUIWindow<BaseCustomLayout>
{
    // [MenuItem("杂鱼工具~~~/TestTool")]
    private static void OpenWindow()
    {
        ToolTemplate window = GetWindow<ToolTemplate>();
        window.Show();
    }

    private void OnGUI() 
    {
        foreach (string key in layout.dicBtn.Keys)
        {
            bool result = GUI.Button(layout.dicBtn[key].rect, layout.dicBtn[key].text, layout.dicBtn[key].style);

            switch (key)
            {
                case "":
                    if (result)
                    {   
                        
                    }
                    break;
            }
        }
        foreach (string key in layout.dicTxt.Keys)
        {
            GUI.Label(layout.dicTxt[key].rect, layout.dicTxt[key].text, layout.dicTxt[key].style);
        }
        foreach (string key in layout.dicIpt.Keys)
        {
            layout.dicIpt[key].text = GUI.TextField(layout.dicIpt[key].rect, layout.dicIpt[key].text, layout.dicIpt[key].style);
        }

        Repaint();
    }
}
