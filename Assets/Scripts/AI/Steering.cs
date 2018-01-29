using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Steering
{
    public float angular;
    public Vector3 linear;
    public Steering()
    {
        angular = 0.0f;
        linear = new Vector3();
    }
}