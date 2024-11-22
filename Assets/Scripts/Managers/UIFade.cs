using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : Singleton<UIFade>
{
    [SerializeField] private Image fadeScreen;
    [SerializeField] private float fadeSpeed;

    private IEnumerator faceRoutine;

    public void FadeToBlack(){
        if(faceRoutine != null){
            StopCoroutine(faceRoutine);
        }

        faceRoutine = FaceRoutine(1);
        StartCoroutine(faceRoutine);
    }
    
    public void FadeToClear(){
        if(faceRoutine != null){
            StopCoroutine(faceRoutine);
        }

        faceRoutine = FaceRoutine(0);
        StartCoroutine(faceRoutine);
    }

    private IEnumerator FaceRoutine(float targetAlpha){
        while(!Mathf.Approximately(fadeScreen.color.a, targetAlpha)){
            float alpha = Mathf.MoveTowards(fadeScreen.color.a, targetAlpha , fadeSpeed * Time.deltaTime);
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, alpha);

            yield return null;
        }
    }
}
