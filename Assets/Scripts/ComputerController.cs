using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerController : MonoBehaviour
{
    public GameObject player;
    public GameObject playerCamera;
    public TMPro.TextMeshProUGUI hoveringText;
    public static bool computerOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= 3 && !computerOpen)
        {
            askToLogOn();
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.GetComponent<PlayerController>().can_move = false;
                player.transform.position = new Vector3(-9.87306786f, 1.01400197f, -14.9893961f);
                player.transform.rotation = new Quaternion(0, 0.707106829f, 0, 0.707106829f);
                Camera.main.fieldOfView = 25;
                computerOpen = true;
            }
        } else
        {
            stopAsking();
        }

        if (computerOpen)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void askToLogOn ()
    {
        hoveringText.text = "'E' TO LOG ON";
    }

    public void stopAsking ()
    {
        hoveringText.text = "";
    }

}
