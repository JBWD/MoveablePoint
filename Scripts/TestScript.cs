using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{

    [MoveablePoint]
    public Vector2 v2Point = new Vector2(2, 0);

    [MoveablePoint]
    public Vector3 v3Point = new Vector2(-2,0);

    [MoveablePoint]
    public Vector2[] v2Points = new Vector2[4];

    [MoveablePoint]
    public List<Vector3> v3Points = new List<Vector3>(4);
    
}
