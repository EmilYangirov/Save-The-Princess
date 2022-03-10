using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindPosition : MonoBehaviour
{
    public Transform bone;
    private void Update()
    {
        BindPositionToBone();
    }

    private void BindPositionToBone()
    {
        transform.position = bone.position;
        transform.rotation = bone.rotation;
    }
}
