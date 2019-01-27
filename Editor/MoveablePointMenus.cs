using UnityEditor;

public class MoveablePointMenus : Editor
{
    [MenuItem("Custom/MoveablePoint/ShowHandles")]
    private static void ShowHandles()
    {
        MoveablePointAttribute.ShowHandles = !MoveablePointAttribute.ShowHandles;
        SceneView.lastActiveSceneView.Repaint();
    }
    [MenuItem("Custom/MoveablePoint/ShowHandles", validate = true)]
    private static bool ShowHandlesValidator()
    {
        return !MoveablePointAttribute.ShowHandles;
    }

    [MenuItem("Custom/MoveablePoint/HideHandles")]
    private static void HideHandles()
    {
        MoveablePointAttribute.ShowHandles = !MoveablePointAttribute.ShowHandles;
        SceneView.lastActiveSceneView.Repaint();
    }
    [MenuItem("Custom/MoveablePoint/HideHandles", validate = true)]
    private static bool HideHandlesValidator()
    {
        return MoveablePointAttribute.ShowHandles;
    }
}