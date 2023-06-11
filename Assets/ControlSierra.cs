using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSierra : MonoBehaviour
{
    public float speed = 6;
    public float lifetime = 2;
    public Vector3 direction = new Vector3(-1, 0, 0);

    Vector3 stepVector;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
        rb = GetComponent<Rigidbody2D>();
        stepVector = speed * direction.normalized;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = stepVector;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {   
        if(other.gameObject.name.Equals("cacique"))
        {
        ControlPersonaje ctr=other.gameObject.GetComponent<ControlPersonaje>();
        if(ctr!= null) ctr.RecibirDisparo();
        }

    }
}
