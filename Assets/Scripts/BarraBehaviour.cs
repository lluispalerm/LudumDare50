using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BarraBehaviour : MonoBehaviour
{
    public float max = 1f;
    public float actual = 0.5f;
    public Image fillImage;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q")){
            actual -= 0.05f;
            Mathf.Clamp(actual, 0, 1);
            fillImage.fillAmount = actual;
        }
        if (Input.GetKeyDown("e")){
            actual += 0.05f;
            Mathf.Clamp(actual, 0, 1);
            fillImage.fillAmount = actual;
        }
    }
}
