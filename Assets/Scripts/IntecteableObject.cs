using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntecteableObject : MonoBehaviour
{
    public int hoursToDo;
    public int minutesToDo;
    public string taskName;
    public bool family;
    public FamilyBehaviour familyMember;
    public AudioClip sound;
    //public UnityEvent event;
    public BoxCollider2D boxCollider;
    public GameObject outline;
    public GameObject canvas;
    public PlayerController playerRef;

    public Controlador controller;


    // Start is called before the first frame update
    void Start()
    {
        outline.SetActive(false);
        canvas.SetActive(false);
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<Controlador>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        playerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        //outline.setActiceTrue
        if(col.gameObject.tag == "Player"){
            //canvas.SetActive(true);
            if(controller.HasTime(this) || family){
                outline.SetActive(true);
                playerRef.currentObject = this;
            }
            
            Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player"){
            outline.SetActive(false);
            //canvas.SetActive(false);
            if(playerRef.currentObject == this) playerRef.currentObject = null;
            Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        }
    }

    public void Action(){
        if(!controller.interactin){
            StartCoroutine(controller.DoAction(this));
        }
    }



}
