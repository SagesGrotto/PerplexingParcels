using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Rigidbody boxRB;
    // Start is called before the first frame update
    void Start()
    {
        boxRB = this.GetComponent<Rigidbody>();
        boxRB.drag = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            boxRB.drag = 1f;
    }
    private void OnCollisionExit(Collision collision)
    {
        boxRB.drag = 5f;
    }
}
