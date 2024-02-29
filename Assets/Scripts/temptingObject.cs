using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class temptingObject : MonoBehaviour
{
    // initializing variables for the player, highlight material, and a gameobject that will be the highlight
    public GameObject player;

    public string actionName;
    public string lossMessage;
    public AudioSource sunshineSource;
    public bool weirdObject = false;
    public float objectHeight;
    public Material highlightMaterial;
    public TMPro.TextMeshProUGUI hoveringText;
    public GameObject spotlightPrefab;
    private AudioSource walkingOnSunshine;
    private bool sunshinePlaying = false;
    public bool loss = false;
    private GameObject spotlight;
    private GameObject highlight;
    private static Color rainbow = new Color(1, 0, 1, .5f);

    private void Start()
    {
        // creating the highlight object that is basically this object with no scripts or collider with a transparent texture on it
        if (!weirdObject)
        {
            highlight = Instantiate(gameObject, transform, true);
            Destroy(highlight.GetComponent<temptingObject>());
            Destroy(highlight.GetComponent<Collider>());
            highlight.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
            highlight.GetComponent<Renderer>().material = highlightMaterial;
        }
        StartCoroutine(rainbowProgression());
        spotlight = Instantiate(spotlightPrefab, transform, true);
        spotlight.GetComponent<SpotlightController>().center = transform.position + new Vector3(0, objectHeight, 0);
        devisualizeTemptation();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= 5 && !loss && !ComputerController.computerOpen)
        {
            devisualizeTemptation();
            if (!weirdObject)
            {
                highlight.gameObject.SetActive(false); // highlight is inactive by default
            }
            if (Vector3.Distance(transform.position, player.transform.position) <= 3) //if player is close enough and looking, set the highlight active
            {
                visualizeTemptation();
                if (sunshinePlaying == false)
                {
                    walkingOnSunshine = Instantiate(sunshineSource, transform, true);
                    sunshinePlaying = true;
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    loss = true;
                    devisualizeTemptation();
                }
            }
            else
            {
                Destroy(walkingOnSunshine);
                sunshinePlaying = false;
            }
        } else if (loss)
        {
            player.GetComponent<PlayerController>().can_move = false;
            Destroy(walkingOnSunshine);
            sunshinePlaying = false;
            hoveringText.rectTransform.anchoredPosition = new Vector3(0, 200, 0);
            hoveringText.text = lossMessage;
            RenderSettings.ambientLight = Color.red;
        }
    }

    public void visualizeTemptation()
    {
        RenderSettings.ambientLight = new Color(0.188235294f, 0.11372549f, 0);
        spotlight.SetActive(true);
        foreach (Renderer renderer in spotlight.GetComponentsInChildren<Renderer>())
        {
            renderer.enabled = true;
        }
        spotlight.transform.GetChild(1).gameObject.SetActive(true);
        spotlight.transform.GetChild(2).gameObject.SetActive(true);
        if (!weirdObject)
        {
            highlight.gameObject.SetActive(true);
        }
        hoveringText.text = "'E' " + actionName;
    }

    public void devisualizeTemptation()
    {
        RenderSettings.ambientLight = Color.white;
        foreach (Renderer renderer in spotlight.GetComponentsInChildren<Renderer>())
        {
            renderer.enabled = false;
        }
        spotlight.transform.GetChild(1).gameObject.SetActive(false);
        spotlight.transform.GetChild(2).gameObject.SetActive(false);
        if (!weirdObject)
        {
            highlight.gameObject.SetActive(false);
        }
        hoveringText.text = "";
    }

        public IEnumerator rainbowProgression()
    {
        while (true)
        {
            if (rainbow.r == 1f && rainbow.g < 1f)
            {
                rainbow.b = Mathf.Clamp(rainbow.b - 0.01f, 0, 1);
                rainbow.g = Mathf.Clamp(rainbow.g + 0.01f, 0, 1);
            }
            if (rainbow.g == 1f && rainbow.b < 1f)
            {
                rainbow.r = Mathf.Clamp(rainbow.r - 0.01f, 0, 1);
                rainbow.b = Mathf.Clamp(rainbow.b + 0.01f, 0, 1);
            }
            if (rainbow.b == 1f && rainbow.r < 1f)
            {
                rainbow.g = Mathf.Clamp(rainbow.g - 0.01f, 0, 1);
                rainbow.r = Mathf.Clamp(rainbow.r + 0.01f, 0, 1);
            }
            highlightMaterial.SetColor("_Color", rainbow);
            hoveringText.color = rainbow;
            yield return new WaitForSeconds(0.005f);
        }
    }
}