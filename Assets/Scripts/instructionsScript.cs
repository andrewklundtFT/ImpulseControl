using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instructionsScript : MonoBehaviour
{
    public TMPro.TextMeshProUGUI hoveringText;
    // Start is called before the first frame update
    void Start()
    {
        ComputerController.computerOpen = true;
        hoveringText.rectTransform.anchoredPosition = new Vector3(0, 200, 0);
        hoveringText.rectTransform.sizeDelta = new Vector2(600, 50);
    }

    // Update is called once per frame
    void Update()
    {
        if (ComputerController.computerOpen)
        {
            hoveringText.text = "TITLE SCREEN! IMPULSE CONTROL: In this game, you are going to work for your company. You must make decisions to avoid any cybersecurity threats. Pressing 'E' will allow you to interact with objects. Press 'E' to exit this guide!";
        }
        if (Input.GetKeyDown(KeyCode.E) && ComputerController.computerOpen)
        {
            ComputerController.computerOpen = false;
            hoveringText.rectTransform.anchoredPosition = new Vector3(0, 60, 0);
            hoveringText.rectTransform.sizeDelta = new Vector2(200, 50);
            hoveringText.text = "";
        }
    }
}
