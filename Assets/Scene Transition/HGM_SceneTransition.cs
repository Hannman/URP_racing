using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class HGM_SceneTransition : MonoBehaviour
{
    [SerializeField] private GameObject loadingBlock;
    [SerializeField] private TMP_Text loadingPercentage;

    private static HGM_SceneTransition instance;

    private AsyncOperation loadingOperation;

    public static void LoadScene(string sceneName)
    {
        instance.StartCoroutine(loadCoroutine(sceneName));
    }


    void Start()
    {
        instance = this;
    }


    void Update()
    {
        if (loadingOperation != null)
        {
            loadingPercentage.text = Mathf.RoundToInt(loadingOperation.progress * 100) + "%";
        }
    }

    public void ShowLoading() 
    {
        loadingBlock.SetActive(true);
    }

    static IEnumerator loadCoroutine(string sceneName)
    {
        yield return new WaitForSeconds(0.5f);
        instance.loadingOperation = SceneManager.LoadSceneAsync(sceneName);
    }
}
