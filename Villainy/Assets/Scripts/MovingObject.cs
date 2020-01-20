using System.Collections;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (PlayPause.playing)
        {
            // Move the object forward along its x axis 1 unit/second
            transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime);            
        }
        
    }
}
