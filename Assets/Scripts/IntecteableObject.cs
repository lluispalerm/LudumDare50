using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntecteableObject : MonoBehaviour
{

    public float timeToDo;
    public string taskName;
    public bool family;

    //public UnityEvent event;
    public BoxCollider2D collider;
    public GameObject outline;
    public GameObject canvas;
    public PlayerController playerRef;


    // Start is called before the first frame update
    void Start()
    {
        outline.SetActive(false);
        canvas.SetActive(false);
        collider = gameObject.GetComponent<BoxCollider2D>();
        playerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        //outline.setActiceTrue
        outline.SetActive(true);
        canvas.SetActive(true);
        playerRef.currentObject = this;
        Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        outline.SetActive(false);
        canvas.SetActive(false);
        Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
    }

    public void Action(){
        Debug.Log("Toma interaccion");
    }



}
