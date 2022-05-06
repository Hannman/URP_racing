using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class SceneTransition : MonoBehaviour
{
    public TMP_Text LoadingPercentage;

    private static SceneTransition instance;
    private static bool shouldPlayOpeningAnimation = false;

    private Animator componentAnimator;
    private AsyncOperation loadingSceneOperation;

    public static void LoadScene(string sceneName) 
    {
        instance.componentAnimator.SetTrigger("closingTrigger");
        instance.loadingSceneOperation = SceneManager.LoadSceneAsync(sceneName);
        instance.loadingSceneOperation.allowSceneActivation = false;
    } 

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        componentAnimator = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (loadingSceneOperation!=null)
        {
            LoadingPercentage.text = Mathf.RoundToInt(loadingSceneOperation.progress * 100) + "%";
            Debug.Log(loadingSceneOperation.progress);
        }
        
        if (shouldPlayOpeningAnimation)
        {
            componentAnimator.SetTrigger("openingTrigger");
            shouldPlayOpeningAnimation = false;
        }

    }

    public void OnAnimationOver() 
    {
        Debug.Log("OnAnimationOver");
        shouldPlayOpeningAnimation = true;
        instance.loadingSceneOperation.allowSceneActivation = true;
    }
}
