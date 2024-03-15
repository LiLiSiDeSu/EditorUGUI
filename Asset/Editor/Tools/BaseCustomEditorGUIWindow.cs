using UnityEditor;
using UnityEngine;

public class BaseCustomEditorGUIWindow<T> : EditorWindow where T : BaseCustomLayout                                                          
{
    protected EditorGUICustomLayoutRoot EditorGUILayoutObj;
    protected static T layout;

    private void Awake()
    {
        EditorGUILayoutObj = FindAnyObjectByType<EditorGUICustomLayoutRoot>();
        if (EditorGUILayoutObj == null)
        {
            GameObject cao = new("EditorGUICustomLayoutRoot");
            EditorGUILayoutObj = cao.AddComponent<EditorGUICustomLayoutRoot>();
        }

        layout = FindAnyObjectByType<T>();
        if (layout == null)
        {
            GameObject obj = new(typeof(T).ToString());
            obj.transform.parent = EditorGUILayoutObj.transform;
            layout = obj.AddComponent<T>();
        }
    }    
}
