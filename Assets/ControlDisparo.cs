using System.Collections;
using System.Threading;
using UnityEngine;

public class ControlDisparo : MonoBehaviour
{
    Collider2D disparando=null;
    public float probabilidadDisparo=1f;
    public GameObject bulletPrototype;
    
    Controlenemigo ctr;
    // Start is called before the first frame update
    void Start()
    {
        /* ctr=GameObject.Find("enemigo").GetComponent<Controlenemigo>();
     */}

    void FixedUpdate(){
        if(Random.value < 1f / (60f * 1.5f)){
            DecidaSiDispara();
        }
    }
    // Update is called once per frame
    /* void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.name.Equals("cacique")&& disparando==null){
            DecidaSiDispara(other);
        } 
    }

    void OnTriggerExit2D(Collider2D other){
        if(other==disparando){
            disparando=null;
        } 
    } */
    void DecidaSiDispara(){
            Disparar();
           
    }

    void Disparar(){
        GameObject bulletCopy=Instantiate(bulletPrototype);
        bulletCopy.transform.position=new Vector3(transform.parent.position.x,transform.parent.position.y,-1f);
        bulletCopy.GetComponent<ControlSierra>().direction =new Vector3(-transform.parent.localScale.x,0,0);
        }
    void Update()
    {
        
    }
}
