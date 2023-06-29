using UnityEditor;
using UnityEngine;
using System.Reflection;
using System.Collections.Generic;

[CustomEditor(typeof(MoveablePointAttribute), true, isFallback = false)]
public class CustomPositionHandle : Editor
{
    private GUIStyle style;
    private MonoBehaviour t;
    private FieldInfo[] fields;

    private void OnEnable()
    {
        t = target as MonoBehaviour;

        style = new GUIStyle
        {
            fontSize = 12,
            fontStyle = FontStyle.Bold
        };
        style.normal.textColor = Color.yellow;

        Handles.color = Color.yellow;

        fields = t.GetType().GetFields(
            BindingFlags.Public |
            BindingFlags.NonPublic |
            BindingFlags.Instance
            );
    }

    private void OnSceneGUI()
    {
        if (t == null)
        {
            return;
        }

        if (!MoveablePointAttribute.ShowHandles)
        {
            return;
        }

        foreach (var fieldInfo in fields)
        {
            var attribs = fieldInfo.GetCustomAttributes(typeof(MoveablePointAttribute), false);

            if (attribs.Length <= 0)
            {
                continue;
            }

            if (fieldInfo.FieldType == typeof(Vector2))
            {
                Vector2 v = UpdateHandle((Vector2)fieldInfo.GetValue(t), fieldInfo.Name);
                fieldInfo.SetValue(t, v);
                continue;
            }

            if (fieldInfo.FieldType == typeof(Vector3))
            {
                Vector3 v = UpdateHandle((Vector3)fieldInfo.GetValue(t), fieldInfo.Name);
                fieldInfo.SetValue(t, v);
                continue;
            }

            if (fieldInfo.FieldType == typeof(Vector2[]))
            {
                Vector2[] v = (Vector2[])fieldInfo.GetValue(t);

                for (int i = 0; i < v.Length; i++)
                {
                    v[i] = UpdateHandle(v[i], fieldInfo.Name + ": " + i);
                }

                fieldInfo.SetValue(t, v);
                continue;
            }

            if (fieldInfo.FieldType == typeof(Vector3[]))
            {
                Vector3[] v = (Vector3[])fieldInfo.GetValue(t);

                for (int i = 0; i < v.Length; i++)
                {
                    v[i] = UpdateHandle(v[i], fieldInfo.Name + ": " + i);
                }

                fieldInfo.SetValue(t, v);
                continue;
            }

            if (fieldInfo.FieldType == typeof(List<Vector2>))
            {
                List<Vector2> v = (List<Vector2>)fieldInfo.GetValue(t);

                for (int i = 0; i < v.Count; i++)
                {
                    v[i] = UpdateHandle(v[i], fieldInfo.Name + ": " + i);
                }

                fieldInfo.SetValue(t, v);
                continue;
            }

            if (fieldInfo.FieldType == typeof(List<Vector3>))
            {
                List<Vector3> v = (List<Vector3>)fieldInfo.GetValue(t);

                for (int i = 0; i < v.Count; i++)
                {
                    v[i] = UpdateHandle(v[i], fieldInfo.Name + ": " + i);
                }

                fieldInfo.SetValue(t, v);
                continue;
            }
        }
    }

    private Vector3 UpdateHandle(Vector3 v, string name)
    {
        v = Handles.PositionHandle(v, Quaternion.identity);
        Handles.Label(v, name, style);
        Handles.DrawWireDisc(v, new Vector3(0, 0, 1), .5f);
        return v;
    }
}
