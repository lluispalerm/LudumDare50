using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyBehaviour : MonoBehaviour
{
    public float willToLive = 1.0f;
    public GameObject[] events;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddWill(int hour, int min){
        willToLive = willToLive + ( 0.1f * hour) + ( 0.01f * min);
        willToLive = Mathf.Clamp(willToLive, 0f, 1f);
    }

    public void RemoveWill(float dayPassedValue){
        willToLive -= dayPassedValue; 
    }



    
}
