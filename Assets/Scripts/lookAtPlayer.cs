using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class lookAtPlayer : MonoBehaviour
{

    public GameObject player;
    public float offset = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position + new Vector3(0, offset, 0));
    }
}
