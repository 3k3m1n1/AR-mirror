using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class ActivateMusicZone : MonoBehaviour
{
    public AudioMixer audioMixer;
    public string audioMixerParameter;
    int zoneCount = 0;

    ParticleSystem particles;
    SpriteRenderer spotlight;
    public float fadeSpeed = 0.4f;
    Coroutine fadeS_in;
    Coroutine fadeS_out;

    bool lightsOn = true;
    ZEDManager zedManager;


    // Start is called before the first frame update
    void Start()
    {
        // grab references from scene
        particles = GetComponentInChildren<ParticleSystem>();
        spotlight = transform.GetChild(3).GetComponent<SpriteRenderer>();
        zedManager = GameObject.Find("ZED_Rig_Mono").GetComponent<ZEDManager>();
    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    IEnumerator FadeVolume(AudioMixer audioMixer, string exposedParam, float duration, float targetVolume)
    {
        // lerps the volume up/down over time instead of abruptly changing it
        float currentTime = 0;
        float currentVol;
        audioMixer.GetFloat(exposedParam, out currentVol);
        currentVol = Mathf.Pow(10, currentVol / 20);    // exposedParam will be 0 dB at full volumme and -80 dB at absolutely silent, so currentVol ranges from 1 max to .0001 min.
        float targetValue = Mathf.Clamp(targetVolume, 0.0001f, 1);
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float newVol = Mathf.Lerp(currentVol, targetValue, currentTime / duration);
            audioMixer.SetFloat(exposedParam, Mathf.Log10(newVol) * 20);
            yield return null;
        }
        yield break;
    }

    IEnumerator FadeSpotlightIn()
    {
        // increment spotlight sprite's alpha over time

        float alphaValue = 0f;
        while (spotlight.color.a < 1)
        {
            alphaValue += fadeSpeed * Time.deltaTime;
            spotlight.color = new Color(1f, 1f, 1f, alphaValue);

            yield return null;
        }
    }

    IEnumerator FadeSpotlightOut()
    {
        // decrement spotlight sprite's alpha over time

        float alphaValue = 1f;
        while (spotlight.color.a > 0)
        {
            alphaValue -= 0.8f * Time.deltaTime;
            spotlight.color = new Color(1f, 1f, 1f, alphaValue);

            yield return null;
        }
    }

    IEnumerator DimTheScene()
    {
        // set the Camera Brightness variable exposed by the ZED Manager:
        //          "Brightness of the final real-world image.
        //          Lower to darken the environment in a realistic way.
        //          This is a rendering setting that doesn't affect the raw input of the camera."

        int brightnessValue = 100;
        while (zedManager.CameraBrightness > 14)
        {
            brightnessValue = (int)(brightnessValue - Time.deltaTime);
            zedManager.CameraBrightness = brightnessValue;

            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // when someone walks into this zone (and it was empty before), increase the volume of its instrument in the Audio Mixer
        if (other.tag == "Visitor")
        {
            zoneCount++;
            //Debug.Log("Visitor entering zone! # of people inside: " + zoneCount);

            if (zoneCount == 1)
            {
                // start particle system
                particles.Play();   
                
                // dim the studio lights, if they haven't been dimmed already
                if (lightsOn)
                {
                    StartCoroutine(DimTheScene());
                    lightsOn = false;
                }

                // fade spotlight on
                if (fadeS_out != null) { StopCoroutine(fadeS_out); }  // this should solve conflicts where both the fadeIn and fadeOut coroutines are running + therefore stop prematurely
                fadeS_in = StartCoroutine(FadeSpotlightIn());

                // fade in the music track
                StartCoroutine(FadeVolume(audioMixer, audioMixerParameter, 0.2f, 1f));    // make sure to type the parameter's name into the inspector! violinVolume, fluteVolume, etc.
                                                                                         // and drag in the audio mixer reference as well
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // if someone leaves the zone AND there is no one else inside, fade out the instrument
        if (other.tag == "Visitor")
        {
            zoneCount--;
            //Debug.Log("A visitor exited. # of people remaining: " + zoneCount);

            if (zoneCount == 0)
            {
                // stop generating particles
                particles.Stop();

                // fade spotlight off
                if (fadeS_in != null) { StopCoroutine(fadeS_in); }  // this should solve conflicts where both the fadeIn and fadeOut coroutines are running + therefore stop prematurely
                fadeS_out = StartCoroutine(FadeSpotlightOut());

                // fade out the music track
                StartCoroutine(FadeVolume(audioMixer, audioMixerParameter, 0.2f, 0.0001f));
            } 
        }
    }

}
