using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class temptingObject : MonoBehaviour
{
    // initializing variables for the player, highlight material, and a gameobject that will be the highlight
    public GameObject player;
    public Material highlightMaterial;
    public string actionName;
    public TMPro.TextMeshProUGUI hoveringText;
    private GameObject highlight;
    private static Color rainbow = new Color(0, 1, 0, .5f);

    void Start()
    {
        // creating the highlight object that is basically this object with no scripts or collider with a transparent texture on it
        highlight = Instantiate(gameObject, transform, true); 
        Destroy(highlight.GetComponent<temptingObject>());
        Destroy(highlight.GetComponent<Collider>());
        highlight.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        highlight.GetComponent<Renderer>().material = highlightMaterial;
    }

    void Update()
    {  
        devisualizeTemptation();
        highlight.gameObject.SetActive(false); // highlight is inactive by default
        if (player.GetComponent<PlayerController>().isPlayerLooking(this.gameObject)) //if player is close enough and looking, set the highlight active
        {
            visualizeTemptation();
        }
    }

    public void visualizeTemptation ()
    {
        highlight.gameObject.SetActive(true);
        hoveringText.text = "'E' " + actionName;


        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("HURRAY!");
            colorChanger();
        }
    }

    public void devisualizeTemptation()
    {
        highlight.gameObject.SetActive(false);
        hoveringText.text = "";
    }

    public void colorChanger ()
    {
        highlightMaterial.SetColor("_Color", rainbow);
    }
}
