using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLanza : MonoBehaviour
{
    ControlPersonaje ctr;
    // Start is called before the first frame update
    void Start()
    {
        ctr = GameObject.Find("cacique").GetComponent<ControlPersonaje>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("rana"))
        {
            ctr.SetControlRana(other.gameObject.GetComponent<Controlenemigo>());
            
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("rana"))
        {
            ctr.SetControlRana(null);
        }
    }
}
