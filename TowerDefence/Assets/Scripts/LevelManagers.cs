using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagers : MonoBehaviour
{
    public static LevelManagers main;

    public Transform startPoint;
    public Transform[] path;

    private void Awake()
    {
        main = this;
    }


}
