using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : MonoBehaviour
{
    public float textTimeDelay;

    // Update is called once per frame
    void Update()
    {
        textTimeDelay -= Time.deltaTime;

        if (textTimeDelay <= 0)
        {
            Destroy(gameObject);
        }
        /*transform.position = new Vector3(transform.parent.position.x, 
                                        transform.parent.position.y+4,
                                        transform.parent.position.z);*/

    }
}
