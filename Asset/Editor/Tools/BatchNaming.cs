using UnityEngine;
using UnityEditor;

public class BatchRename : BaseCustomEditorGUIWindow<LayoutForBatchRename>
{    
    [MenuItem("杂鱼工具~~~/Batch Rename")]
    private static void OpenWindow()
    {
        BatchRename window = GetWindow<BatchRename>();
        window.Show();
    }      

    private void OnGUI() 
    {
        foreach (string key in layout.dicBtn.Keys)
        {
            bool result = GUI.Button(layout.dicBtn[key].rect, layout.dicBtn[key].text, layout.dicBtn[key].style);

            switch (key)
            {
                case "BtnRename":
                    if (result)
                    {   
                        Rename();//
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

    private void Rename()
    {
        GameObject[] selectedObjects = Selection.gameObjects;

        try
        {
            for (int i = 0; i < selectedObjects.Length; i++)
            {            
                selectedObjects[i].name = layout.dicIpt["IptBaseName"].text + (int.Parse(layout.dicIpt["IptStartIndex"].text) + i);
            }
        }
        catch
        {
            Debug.Log("StartIndex只能是正常的数字哦~ 杂鱼!~~~");            
        }
    }
}