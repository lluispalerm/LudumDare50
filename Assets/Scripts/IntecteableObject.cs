using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntecteableObject : MonoBehaviour
{

    public float timeToDo;
    public string taskName;
    public bool family;

    public UnityEvent event;
    public BoxCollider2D collider;
    public GameObject outline;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
    }

}
