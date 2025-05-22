using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagers : MonoBehaviour
{

    public static LevelManagers main;

    public Transform startPoint1;
    public Transform startPoint2;

    public Transform[] path1;
    public Transform[] path2;

    public void Awake()
    {
        main = this;
    }
}
