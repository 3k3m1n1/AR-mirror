using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class ActivateMusicZone : MonoBehaviour
{
    public AudioMixer audioMixer;
    public string audioMixerParameter;
    private int zoneCount = 0;
    
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    IEnumerator StartFade(AudioMixer audioMixer, string exposedParam, float duration, float targetVolume)
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

    private void OnTriggerEnter(Collider other)
    {
        // when someone walks into this zone (and it was empty before), increase the volume of its instrument in the Audio Mixer
        if (other.tag == "Visitor")
        {
            zoneCount++;
            Debug.Log("Visitor entering zone! # of people inside: " + zoneCount);

            if (zoneCount == 1)
            {
                StartCoroutine(StartFade(audioMixer, audioMixerParameter, 0.2f, 1f));    // make sure to type the parameter's name into the inspector! violinVolume, fluteVolume, etc.
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
            Debug.Log("A visitor exited. # of people remaining: " + zoneCount);

            if (zoneCount == 0)
            {
                StartCoroutine(StartFade(audioMixer, audioMixerParameter, 0.2f, 0.0001f));
            } 
        }
    }

}
