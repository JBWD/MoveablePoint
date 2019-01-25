using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

[CustomEditor(typeof(MonoBehaviour),true,isFallback = false)]
public class CustomPositionHandle : Editor
{
    

    void OnSceneGUI()
    {
        //Checks all MonoBehavior Elements for the attribute attached to the object.
        var t = target as MonoBehaviour;
        
        if (t == null) return;
        //Changes the style of the text and Color of the circles.
        GUIStyle style = new GUIStyle();

        style.fontSize = 12;
        style.fontStyle = FontStyle.Bold;
        style.normal.textColor = Color.yellow;

        Handles.color = Color.yellow;

        //Goes through each of the variables within the script.
        foreach (var fieldInfo in t.GetType().GetFields())
        {
            try
            {
                //Makes sure the variable has the flag of the type.
                var attribs = fieldInfo.GetCustomAttributes(typeof(MoveablePointAttribute), false);

                //If the length is >0 it means it has the flag attached.
                //Also checks for the type of field it is to make sure it is valid.

                if (attribs.Length > 0 && fieldInfo.FieldType == typeof(Vector3))
                {
                    //Converts the information to a Vector3
                    Vector3 v = (Vector3)fieldInfo.GetValue(t);
                    //Builds the handle
                    v = Handles.PositionHandle(v, Quaternion.identity);
                    //Adds a label of the variables name.
                    Handles.Label(v, fieldInfo.Name, style);
                    //Sets the value if the variable changes.
                    fieldInfo.SetValue(t, v);
                }
               
                else if (attribs.Length > 0 && fieldInfo.FieldType == typeof(Vector2))
                {
                    //Converts the information to a Vector3
                    Vector2 v = (Vector2)fieldInfo.GetValue(t);
                    //Builds the handle
                    v = Handles.PositionHandle(v, Quaternion.identity);
                    //Adds a label of the variables name.
                    Handles.Label(v, fieldInfo.Name, style);
                    //Sets the value if the variable changes.
                    fieldInfo.SetValue(t, v);
                }
                else if(attribs.Length > 0 && fieldInfo.FieldType == typeof(Vector2[]))
                {
                    //Retrieves the array of elements.
                    Vector2[] values = (Vector2[])fieldInfo.GetValue(t);
                    //Iterates through the array.
                    for (int i = 0; i < values.Length; i++)
                    {
                        //Creates a handle for each element
                        values[i] = Handles.PositionHandle(values[i], Quaternion.identity);
                        
                        //Labels the element with it's index in the array.
                        Handles.Label(new Vector3(values[i].x+.5f,values[i].y), i.ToString(),style);
                        //Draws a circle for easier location within the scene.
                        Handles.DrawWireDisc(values[i], new Vector3(0,0, 1), .5f);
                    }
                    //Changes all of the values within the array.
                    fieldInfo.SetValue(t, values);
                }

                else if (attribs.Length > 0 && fieldInfo.FieldType == typeof(Vector3[]))
                {

                    //Retrieves the array of elements.
                    Vector3[] values = (Vector3[])fieldInfo.GetValue(t);
                    //Iterates through the array.
                    for (int i = 0; i < values.Length; i++)
                    {
                        //Creates a handle for each element
                        values[i] = Handles.PositionHandle(values[i], Quaternion.identity);

                        //Labels the element with it's index in the array.
                        Handles.Label(new Vector3(values[i].x + .5f, values[i].y), i.ToString(), style);
                        //Draws a circle for easier location within the scene.
                        Handles.DrawWireDisc(values[i], new Vector3(0, 0, 1), .5f);
                    }
                    //Changes all of the values within the array.
                    fieldInfo.SetValue(t, values);
                }
                else if (attribs.Length > 0 && fieldInfo.FieldType == typeof(List<Vector2>))
                {

                    //Retrieves the array of elements.
                    List<Vector2> values = (List<Vector2>)fieldInfo.GetValue(t);
                    //Iterates through the array.
                    for (int i = 0; i < values.Count; i++)
                    {
                        //Creates a handle for each element
                        values[i] = Handles.PositionHandle(values[i], Quaternion.identity);

                        //Labels the element with it's index in the array.
                        Handles.Label(new Vector3(values[i].x + .5f, values[i].y), i.ToString(), style);
                        //Draws a circle for easier location within the scene.
                        Handles.DrawWireDisc(values[i], new Vector3(0, 0, 1), .5f);
                    }
                    //Changes all of the values within the array.
                    fieldInfo.SetValue(t, values);
                }
                else if (attribs.Length > 0 && fieldInfo.FieldType == typeof(List<Vector3>))
                {

                    //Retrieves the array of elements.
                    List<Vector3> values = (List<Vector3>)fieldInfo.GetValue(t);
                    //Iterates through the array.
                    for (int i = 0; i < values.Count; i++)
                    {
                        //Creates a handle for each element
                        values[i] = Handles.PositionHandle(values[i], Quaternion.identity);

                        //Labels the element with it's index in the array.
                        Handles.Label(new Vector3(values[i].x + .5f, values[i].y), i.ToString(), style);
                        //Draws a circle for easier location within the scene.
                        Handles.DrawWireDisc(values[i], new Vector3(0, 0, 1), .5f);
                    }
                    //Changes all of the values within the array.
                    fieldInfo.SetValue(t, values);
                }
                
            }
            catch (System.Exception)
            {
                // ignored
            }
        }
    }





}
