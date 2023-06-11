using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class ControlPersonaje : MonoBehaviour
{
    Rigidbody2D rgb;
    Animator anim;
    AudioSource aSource;
    public float maxVel;
    public bool haciaDerecha;
    int numGolpesMorir=15;
    public Slider slider;
    public Text txt;

    public float salud = 100;

    bool enFire1 = false;

    Controlenemigo ctrRana = null;
    
    ControlManzana ctrManzana=null;
    public GameObject lanza=null;

    public bool jumping=false;
    public float yJumpForce=700;
    Vector2 jumpForce;
    
    public AudioClip ataque;
    public AudioClip muere;


    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        maxVel = 12f;
        haciaDerecha = true;
        jumpForce= new Vector2(0,0);
        aSource= GetComponent<AudioSource>();
        rgb.freezeRotation=true; 
        }
    void Update()
    {

        if (Mathf.Abs(Input.GetAxis("Fire1")) > 0.01f)
        {
            if (enFire1 == false)
            {
                enFire1 = true;

                anim.SetTrigger("Atacar");
                aSource.PlayOneShot(ataque);
                if (ctrRana != null)
                {
                   ctrRana.GolpeCacique();
                }
            }
        }
        else
        {
            enFire1 = false;
        }
        slider.value = salud;
        txt.text = salud.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            if(transform.rotation.z != 0){
            }
        float v = Input.GetAxis("Horizontal");
        Vector2 vel = new Vector2(maxVel, rgb.velocity.y);
        v *= maxVel;
        vel.x = v;
        rgb.velocity = vel;
        VerificarInputParaSaltar();
        anim.SetFloat("speed", vel.x);
            if (haciaDerecha && v < 0)
        {
            haciaDerecha = false;
            Flip();
        }
        else if(!haciaDerecha && v > 0)
        {
            haciaDerecha = true;
            Flip();
        }

    }
        private void VerificarInputParaSaltar(){
        bool isOnTheFloor = rgb.velocity.y == 0;

        if(Input.GetAxis("Jump")>0.01f){
            if(!jumping && isOnTheFloor){
                jumping=true;
                anim.SetTrigger("Saltar");
                jumpForce.x=0f;
                jumpForce.y=yJumpForce;
                rgb.AddForce(jumpForce);
            }
            else{
                jumping=false;
                anim.SetTrigger("Caminar");
            }
        }
        }

        void Flip()
        {
            var s = transform.localScale;
            s.x *= -1;
            transform.localScale=s;
        }
    

    public bool RecibirDisparo(){
        bool resp=false;
        numGolpesMorir--;
        if(salud>0){
        aSource.PlayOneShot(muere);
        anim.SetTrigger("golpe");
        anim.SetTrigger("Caminar");
        this.salud -= salud/numGolpesMorir;
         }
         else{
            resp=true;/* 
            aSource.PlayOneShot(muere); */
            Destroy(gameObject);
         }
        return resp;
    }
    
    public void SetControlRana(Controlenemigo ctr)
    {
        ctrRana = ctr;
    }
    public void SetControlManzana(ControlManzana ctr)
    {
        ctrManzana = ctr;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("manzana"))
        {
            this.SetControlManzana(other.gameObject.GetComponent<ControlManzana>());
            ctrManzana.TomarManzana();
            this.salud+=10;
        }
    }
}
