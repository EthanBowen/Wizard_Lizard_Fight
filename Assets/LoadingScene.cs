using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    public Slider slider; 
    private Transform bar;
    private float loading = 0;
    private float endLoadTime = 100f;
    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("Bar");
        StartCoroutine(LoadAsyncOperation());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadAsyncOperation()
    {
        //create an async operation
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(3);
        
        while(!gameLevel.isDone)
        {
            //fill async operation
            float progress = Mathf.Clamp01(gameLevel.progress / .9f);

            slider.value = progress;
            
            yield return new WaitForEndOfFrame();
        }
        
    }
}
