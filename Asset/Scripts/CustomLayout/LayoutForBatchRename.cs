using System.Collections.Generic;
using EditorGUICustomLayout;

public class LayoutForBatchRename : BaseCustomLayout
{
    protected override void Awake()
    {
        base.Awake();

        InitProperties
        (
            new Dictionary<string, Button>()
            {
                { "BtnRename", new() },
            },
            new Dictionary<string, Text>()
            {
                { "TxtIptBaseNameTitle", new() },
                { "TxtIptStartIndexTitle", new() },
            },
            new Dictionary<string, EditorGUICustomLayout.Input>()
            {
                { "IptBaseName", new() },
                { "IptStartIndex", new() },
            }
        );
    }
}