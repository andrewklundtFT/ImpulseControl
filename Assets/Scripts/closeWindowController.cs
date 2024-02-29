using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeWindowController : MonoBehaviour
{
    public static bool win = false;
    public TMPro.TextMeshProUGUI hoveringText;

    private void OnMouseOver()
    {
        if (ComputerController.computerOpen)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RenderSettings.ambientLight = Color.green;
                hoveringText.rectTransform.anchoredPosition = new Vector3(0, 200, 0);
                hoveringText.text = "YOU WIN!! You didn't make any mistakes!!";
                win = true;
                Debug.Log("close");
            }
        }
    }
}
