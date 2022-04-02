using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    public float deadZone;


    private IntecteableObject currentObject;

    // Start is called before the first frame update
    void Start()
    {

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

    }

    public void Interact(){
        if(currentObject != null){
            //IntecteableObject.action();

        }
    }
}
