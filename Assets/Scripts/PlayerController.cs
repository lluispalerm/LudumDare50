using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    public float deadZone;
    public Rigidbody2D rb;

    public bool canMove = true;

    //Ref
    public IntecteableObject currentObject;
    public SpriteRenderer palerRenderer;

    //Movement
    public Sprite[] sprites;
    private bool moving = false;
    [Header("Animation")]
    public int iterator = 0;
    public int limitIterator = 5;
    public int mFrame = 1;

    // Start is called before the first frame update
    void Start()
    {
        //controller = gameObject.GetComponent<CharacterController>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        palerRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove){
            if (Input.GetKeyDown("space")){
                Interact();
            }

            float hAxis = Input.GetAxis("Horizontal");
            if (Mathf.Abs(hAxis) > 0.3f){
                moving = true;
                Move(hAxis);
            }
            else{
                if(moving){ 
                    palerRenderer.sprite = sprites[0];
                    mFrame = 1;
                }
                moving = false;
            }

            if(moving){
                palerRenderer.sprite = sprites[mFrame];
                if(iterator >= limitIterator){
                    mFrame++;
                    if(mFrame >= sprites.Length) mFrame = 1;
                    iterator = -1;
                }
                iterator++;
            }
        }

        
    }

    public void Move(float hAxis){
        //controller.Move((new Vector3(speed,0,0) * hAxis) * Time.deltaTime);
        //rb.Move( * Time.deltaTime);
        if(hAxis < 0) palerRenderer.flipX = true;
        else palerRenderer.flipX = false;
        rb.MovePosition(rb.position + (new Vector2(speed,0) * hAxis) * Time.fixedDeltaTime);
    }

    public void Interact(){
        if(currentObject != null){
            currentObject.Action();
        }
    }
}
