using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class isPlayerLookingAtMe : MonoBehaviour
{
    public GameObject player;
    public Material green;
    private GameObject outline;

    // Start is called before the first frame update
    void Start()
    {
        outline = Instantiate(gameObject, transform, true);
        Destroy(outline.GetComponent<isPlayerLookingAtMe>());
        Destroy(outline.GetComponent<Collider>());
        outline.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        outline.GetComponent<Renderer>().material = green;
    }

    // Update is called once per frame
    void Update()
    {
        outline.gameObject.SetActive(false);

        if ((player.transform.position - transform.position).magnitude < 3)
        {
            if (Physics.Raycast(player.transform.GetChild(0).transform.position, player.transform.GetChild(0).transform.TransformDirection(Vector3.forward), 3))
            {
                Debug.Log(player.transform.GetChild(0).transform.TransformDirection(Vector3.forward));
                outline.gameObject.SetActive(true);
            }
        }

    }
}
