using UnityEngine;
using UnityEditor;

public class BatchRename : EditorUGUIWindow<EditorPanelBatchRename>
{    
    [MenuItem("杂鱼工具~~~/Batch Rename")]
    private static void OpenWindow()
    {
        BatchRename window = GetWindow<BatchRename>();
        window.Show();
    }

    public override void BtnCallback(bool p_result, string p_btnName)
    {
        base.BtnCallback(p_result, p_btnName);

        switch (p_btnName)
        {
            case "BtnRename":
                if (p_result)
                {   
                    Rename();
                }
                break;
        }
    }

    private void Rename()
    {
        GameObject[] selectedObjects = Selection.gameObjects;

        try
        {
            for (int i = 0; i < selectedObjects.Length; i++)
            {            
                selectedObjects[i].name = panel.dicIpt["IptBaseName"].text + (int.Parse(panel.dicIpt["IptStartIndex"].text) + i);
            }
        }
        catch
        {
                    
        }
    }
}