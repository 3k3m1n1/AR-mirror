using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLightWithMotion : MonoBehaviour
{
    public Light plantLight;
    public float maxIntensity = 2.16f;
    
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    //void Update()
    //{

    //}

    private void OnTriggerStay(Collider other)
    {
        //
        if (other.tag == "Visitor")
        {
            //
            //GameObject leftHand = GameObject.FindGameObjectWithTag("VisitorLHand");

            //GameObject leftHand = other.transform.Find("mixamorig:LeftHand").gameObject;
            //Debug.Log("hand at X position: " + leftHand.transform.position.x);

            float multiplier = Mathf.InverseLerp(-1.2f, 0.7f, other.transform.position.x);
            // intensity should go from 0 to 2.16
            plantLight.intensity = multiplier * maxIntensity;
        }
    }
}
