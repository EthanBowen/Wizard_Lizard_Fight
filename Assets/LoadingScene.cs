using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] private GameObject progressBar;
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
        float loadTime = loading / endLoadTime;
        while(gameLevel.progress < 1)
        {
            
            //fill async operation
            loading++;
            bar.localScale = new Vector3 (loadTime,1f);
            
        }
        yield return new WaitForEndOfFrame();
    }
}
