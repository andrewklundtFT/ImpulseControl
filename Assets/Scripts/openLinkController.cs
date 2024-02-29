using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openLinkController : MonoBehaviour
{

    public AudioSource sunshineSource;
    private AudioSource walkingOnSunshine;
    private bool sunshinePlaying = false;
    public TMPro.TextMeshProUGUI hoveringText;
    private bool lost = false;

    private void OnMouseOver()
    {
        if (ComputerController.computerOpen)
        {
            if (sunshinePlaying == false)
            {
                walkingOnSunshine = Instantiate(sunshineSource, transform, true);
                sunshinePlaying = true;
            }

            if (Input.GetMouseButtonDown(0))
            {

                Destroy(walkingOnSunshine);
                lost = true;
                
            }
        }
    }

    private void LateUpdate()
    {
        if (lost) {

            RenderSettings.ambientLight = Color.red;
            hoveringText.rectTransform.anchoredPosition = new Vector3(0, 200, 0);
            hoveringText.text = "NO. Never click on a link in an email from someone you don't know!";
        }
    }
}
