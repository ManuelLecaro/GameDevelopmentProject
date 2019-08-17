using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appearance : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject clue;
    public GameObject msg;
    
    void Start()
    {
        msg.SetActive(false);
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D colisionar)
    {
        var newObject = colisionar.collider.gameObject;
        if (newObject.tag == "Player")
        {
            msg.SetActive(true);

        }
    }
}
