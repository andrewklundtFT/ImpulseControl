using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightController : MonoBehaviour
{
    public Vector3 center;
    public Material coneMaterial;
    private Color rainbow = new Color(1, 0, 1, 0.9f);

    private void Start()
    {
        transform.position = center + new Vector3(0, 2.5f, 2.5f);
        StartCoroutine(rainbowProgression());
    }
    void Update()
    {
        transform.RotateAround(center, Vector3.up, 150 * Time.deltaTime);
        transform.LookAt(center);
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
            coneMaterial.EnableKeyword("_EMISSION");
            coneMaterial.SetColor("_EmissionColor", rainbow);
            yield return new WaitForSeconds(0.005f);
        }
    }
}
