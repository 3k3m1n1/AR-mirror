using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowersWhereYouWalk : MonoBehaviour
{
    GameObject[] visitors;
    public GameObject flowerPrefab;
    public float floorY = -0.7f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GrowFlowers());
    }

    IEnumerator GrowFlowers()
    {
        while (true)
        {
             // find all visitors in scene
            visitors = GameObject.FindGameObjectsWithTag("Visitor");

            // for each one, spawn a flower/plant at their XZ coordinates and Y = the floor
            foreach (GameObject visitor in visitors)
            {
                Instantiate(flowerPrefab, new Vector3(visitor.transform.position.x + Random.Range(-0.3f, 0.3f), floorY, visitor.transform.position.z + Random.Range(-0.3f, 0.3f)), Quaternion.Euler(0f, Random.Range(-45f, 45f), 0f), this.transform);
            }

            yield return new WaitForSeconds(Random.Range(0.5f, 2));
        }
    }
}
