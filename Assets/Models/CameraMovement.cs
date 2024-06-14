using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C : MonoBehaviour
{

    public Transform cameraPosition;
    void Update()
    {
        transform.position = cameraPosition.position;
    }
}
