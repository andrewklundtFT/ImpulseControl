using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeWindowController : MonoBehaviour
{
    public AudioSource sunshineSource;
    private AudioSource walkingOnSunshine;
    public TMPro.TextMeshProUGUI hoveringText;

    private void OnMouseOver()
    {
        if (ComputerController.computerOpen)
        {
            if (Input.GetMouseButtonDown(0))
            {
                walkingOnSunshine = Instantiate(sunshineSource, transform, true);
                RenderSettings.ambientLight = Color.black;
                hoveringText.rectTransform.anchoredPosition = new Vector3(0, 200, 0);
                hoveringText.text = "YOU WIN!! You didn't make any mistakes!!";
                Debug.Log("close");
            }
        }
    }
}
