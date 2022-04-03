using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controlador : MonoBehaviour
{
    [Header("Timer")]
    public Timer timer;
    [Header("Transitions")]
    public Image transitionImage;
    public float transitionVelocity = 0.05f;

    public AudioSource source;

    public FamilyBehaviour[] family;

    public bool interactin = false;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        timer.Reset();
        StartCoroutine(StartTransition());
    }
    
    private IEnumerator StartTransition()
    {
        timer.isTransitioning = true;
        float alpha = 1.0f;
        while (transitionImage.color.a > 0.0f)
        {
            alpha -= transitionVelocity *Time.deltaTime;
            Color color = new Color(transitionImage.color.r, transitionImage.color.g, transitionImage.color.b, alpha);
            transitionImage.color = color;
            yield return null;
        }
        timer.isTransitioning = false;
        yield return null;
    }
    private IEnumerator EndTransition()
    {
        timer.isTransitioning = true;
        float alpha = 0.0f;
        while (transitionImage.color.a < 1.0f)
        {
            alpha += transitionVelocity *Time.deltaTime;
            Color color = new Color(transitionImage.color.r, transitionImage.color.g, transitionImage.color.b, alpha);
            transitionImage.color = color;
            yield return null;
        }
        timer.isTransitioning = false;
        yield return null;
    }
    public IEnumerator DoAction(IntecteableObject obj)
    {
        interactin = true;
        yield return StartCoroutine(EndTransition());
        timer.isTransitioning = true;
        timer.ApplyTimeLoss(obj.hoursToDo, obj.minutesToDo);
        if(obj.sound != null){
            source.clip = obj.sound;
            source.Play();
            yield return new WaitForSeconds(obj.sound.length);
        }
        
        yield return StartCoroutine(StartTransition());
        interactin = false;
    }

}
