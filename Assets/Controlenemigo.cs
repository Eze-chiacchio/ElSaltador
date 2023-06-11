using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlenemigo : MonoBehaviour
{
    public float vel = -1f;
    Rigidbody2D rgb;
    Animator anim;
    public int numGolpesMorir = 3;

    public bool jumping=false;
    public float yJumpForce=700;
    Vector2 jumpForce;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        jumpForce= new Vector2(0,0);
        rgb.freezeRotation=true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 v = new Vector2(vel, 0);
        rgb.velocity = v;

        bool isOnTheFloor = rgb.velocity.y == 0;


        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Caminando") && Random.value < 1f / (60f * 3f))
        {
            if(!jumping && isOnTheFloor){
                
                anim.SetTrigger("Saltar");
                jumping=true;
                jumpForce.x=0f;
                jumpForce.y=yJumpForce;
                rgb.AddForce(jumpForce);
            }else{
                jumping=false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Flip();
    }

    void Flip()
    {
        vel *= -1;
        var s = transform.localScale;
        s.x *= -1;
        transform.localScale = s;
    }

    public bool GolpeCacique()
    {
        bool resp=false;
        numGolpesMorir--;
        if(numGolpesMorir>=0){
        anim.SetTrigger("golpe");
        anim.SetTrigger("caminar");
         }
         else{
            resp=true;
            Destroy(gameObject);
         }
        return resp;
    }
}
    /* public void Disparar(){
        anim.SetTrigger("Saltar ");
    }
    public void EmitirBala(){
        
    } */

