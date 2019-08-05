using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hightrap : MonoBehaviour
{
    public Transform target1;
    public triggerTrap trigger;
    public float velocity;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger.activate)
        {
            transform.position = Vector2.MoveTowards(transform.position, target1.position, velocity * Time.deltaTime);
        }
        
    }

}
