using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Equipmentizer : MonoBehaviour
{
    public SkinnedMeshRenderer target;

    void Start()
    {
        GetComponent<SkinnedMeshRenderer>().bones = target.bones;
    }
}