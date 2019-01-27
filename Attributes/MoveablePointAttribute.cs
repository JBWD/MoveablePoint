using System;
using UnityEngine;

/// <summary>
/// Allows for the use of [MoveablePoint] on all Vector2 and Vector3 type variables. Including []'s and List<>'s
/// </summary>
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Struct)]
public class MoveablePointAttribute : PropertyAttribute
{
    public static bool ShowHandles = true;
}