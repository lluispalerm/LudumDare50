using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    public float deadZone;
    public Rigidbody2D rb;

    public IntecteableObject currentObject;

    // Start is called before the first frame update
    void Start()
    {
        //controller = gameObject.GetComponent<CharacterController>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")){
            Interact();
        }

        float hAxis = Input.GetAxis("Horizontal");
        if (Mathf.Abs(hAxis) > 0.3f){
            Move(hAxis);
        }
    }

    public void Move(float hAxis){
        //controller.Move((new Vector3(speed,0,0) * hAxis) * Time.deltaTime);
        //rb.Move( * Time.deltaTime);
        rb.MovePosition(rb.position + (new Vector2(speed,0) * hAxis) * Time.fixedDeltaTime);
    }

    public void Interact(){
        if(currentObject != null){
            currentObject.Action();
        }
    }
}
