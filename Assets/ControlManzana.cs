using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManzana : MonoBehaviour
{
    Animator anim;
    AudioSource aSource; 
    public AudioClip tomar;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger("base");
        aSource= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TomarManzana(){
        anim.SetTrigger("tomada");
        aSource.PlayOneShot(tomar);
        Invoke("Destruir",1);
        }
    public void Destruir(){
        Destroy(gameObject);
    }
}
