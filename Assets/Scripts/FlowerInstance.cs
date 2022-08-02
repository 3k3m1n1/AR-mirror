using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerInstance : MonoBehaviour
{
    MeshRenderer meshRenderer;
    public float fadeSpeed = 0.4f;
    public float scaleSpeed = 0.6f;

    Transform anchorPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        anchorPoint = this.transform.GetChild(0);
        StartCoroutine(FadeIn());
        StartCoroutine(Grow());
        StartCoroutine(FadeOut());

        // despawn flower after a few seconds
        Destroy(gameObject, 7f);
    }

    IEnumerator FadeIn()
    {
        // fade in the flower by increasing the opacity over time

        float alphaValue = 0f;
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
        // make the flower "grow" out of the ground by increasing the scale over time
        float scaleValue = 0f;

        while (anchorPoint.localScale.x < 1)
        {
            //
            scaleValue += scaleSpeed * Time.deltaTime;
            anchorPoint.localScale = new Vector3(scaleValue, scaleValue, scaleValue);

            yield return null;
        }
    }

    IEnumerator FadeOut()
    {
        // start to fade out the flower before despawning
        yield return new WaitForSeconds(5f);

        float alphaValue = 1f;
        Color matColor = meshRenderer.material.color;

        while (meshRenderer.material.color.a > 0)
        {
            alphaValue -= 0.8f * Time.deltaTime;
            meshRenderer.material.color = new Color(matColor.r, matColor.g, matColor.b, alphaValue);

            yield return null;
        }
    }
}
