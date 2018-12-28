using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFlow : MonoBehaviour
{
    public Transform target;
    private Vector3 deltaPos;
    // Start is called before the first frame update
    void Start()
    {
        deltaPos = target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       // transform.position = target.position - deltaPos;
    }
}
