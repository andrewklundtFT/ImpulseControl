using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowlyLookAtPlayer : MonoBehaviour
{
    public GameObject player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(player.transform.position + new Vector3(0, 0.5f, 0) - transform.position), 0.2f * Time.deltaTime);
    }
}
