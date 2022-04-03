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
    public GameObject canvasDay; 
    public GameObject[] canvasBar;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        if(timer)
            timer.Reset();
        if(canvasDay)
            canvasDay.SetActive(false);
        StartCoroutine(StartTransition());
    }
    
    private IEnumerator StartTransition()
    {
        if(timer)
            timer.isTransitioning = true;
        float alpha = 1.0f;
        while (transitionImage.color.a > 0.0f)
        {
            alpha -= transitionVelocity *Time.deltaTime;
            Color color = new Color(transitionImage.color.r, transitionImage.color.g, transitionImage.color.b, alpha);
            transitionImage.color = color;
            yield return null;
        }
        if(timer)
            timer.isTransitioning = false;
        yield return null;
    }

    private IEnumerator EndTransition()
    {
        if(timer)
            timer.isTransitioning = true;
        float alpha = 0.0f;
        while (transitionImage.color.a < 1.0f)
        {
            alpha += transitionVelocity *Time.deltaTime;
            Color color = new Color(transitionImage.color.r, transitionImage.color.g, transitionImage.color.b, alpha);
            transitionImage.color = color;
            yield return null;
        }
        if(timer)
            timer.isTransitioning = false;
        yield return null;
    }

    public IEnumerator DoAction(IntecteableObject obj)
    {
        interactin = true;
        yield return StartCoroutine(EndTransition());
        if(timer)
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
    
    public bool HasTime(IntecteableObject obj){
        if(timer.hours == obj.hoursToDo){
            if(timer.minutes < obj.minutesToDo){
                return false;
            }
        }
        else if(timer.hours < obj.hoursToDo){
            return false;
        }

        return true;
    }

    private void StartNewDay(){
        interactin = true;
        timer.isTransitioning = true;
        StartCoroutine(transiotionToNextDay());

    }

    private IEnumerator transiotionToNextDay()
    {
        if (canvasDay)
            canvasDay.SetActive(true);
        yield return null;

        interactin = true;
        timer.isTransitioning = true;
    }

}
