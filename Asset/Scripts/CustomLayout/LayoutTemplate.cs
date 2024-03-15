using System.Collections.Generic;
using EditorGUICustomLayout;

public class LayoutTemplate : BaseCustomLayout
{
    protected override void Awake()
    {
        base.Awake();

        InitProperties
        (
            new Dictionary<string, Button>()
            {
                { "Btn", new() },
            },
            new Dictionary<string, Text>()
            {
                { "Txt", new() },
            },
            new Dictionary<string, EditorGUICustomLayout.Input>()
            {
                { "Ipt", new() },
            }
        );
    }
}
