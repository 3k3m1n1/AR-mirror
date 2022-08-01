using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerInstance : MonoBehaviour
{
    MeshRenderer meshRenderer;
    public float fadeSpeed = 0.4f;
    
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        // fade in the object by lerping the opacity over time

        float alphaValue = 0;
        Color matColor = meshRenderer.material.color;

        while (meshRenderer.material.color.a < 1)
        {
            alphaValue += fadeSpeed * Time.deltaTime;
            meshRenderer.material.color = new Color(matColor.r, matColor.g, matColor.b, alphaValue);

            yield return null;
        }
    }

    IEnumerator Grow()
    {
        //
        yield return null;
    }
}
