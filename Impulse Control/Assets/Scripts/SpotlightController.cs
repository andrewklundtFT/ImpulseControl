using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightController : MonoBehaviour
{
    public GameObject center;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(center.transform.position, Vector3.up, 100 * Time.deltaTime);
        transform.LookAt(center.transform.position);
    }
}
