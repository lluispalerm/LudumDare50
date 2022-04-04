using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BarraBehaviour : MonoBehaviour
{
    public float max = 1f;

    public float actual = 0.5f;
    public Slider fillImage;
    public Image icon;

    void Start(){
        fillImage.value = actual;
    }
    // Update is called once per frame
    void Update()
    {
        //For demo
        /*if (Input.GetKeyDown("q")){
            UpdateBarraStatus(-0.05f);
        }
        if (Input.GetKeyDown("e")){
            Debug.Log(PercentageActual());
            UpdateBarraStatus(0.05f);
        }*/
    }

    public void UpdateBarraStatus(float value = -0.05f)
    {
        actual = value;
        actual = Mathf.Clamp(actual, 0, 1);
        fillImage.value = actual;
    }

    public float PercentageActual() => actual * 100.0f;
}
