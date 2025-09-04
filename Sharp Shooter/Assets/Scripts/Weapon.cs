using UnityEngine;

public class Weapon : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))      
        {
            Debug.Log(hit.collider.name);
        }
    }
}
