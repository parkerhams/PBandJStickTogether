﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBob : MonoBehaviour
{

    public Transform start;
    public Transform end;

    public float factor = 1.0f;

    void Start()
    {
        SetPos(start.position, end.position);
    }

    void Update()
    {
        SetPos(start.position, end.position);
    }

    void SetPos(Vector3 start, Vector3 end)
    {
        var dir = end - start;
        var mid = (dir) / 2.0f + start;
        transform.position = mid;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        Vector3 scale = transform.localScale;
        scale.y = dir.magnitude * factor;
        transform.localScale = scale;
    }
}
