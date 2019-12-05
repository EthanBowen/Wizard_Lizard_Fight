using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapSelection : MonoBehaviour
{
    public GameObject currentHoveredMap;
    public GameObject currentSelectedMap;
    public List<Sprite> maps;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnMouseOver()
    {
        currentHoveredMap.GetComponent<Image>().sprite = maps[1];
    }
    public void ChangeSceneRR()
    {
        SceneManager.LoadScene("Game");
    }

    public void ChangeSceneSL()
    {
        SceneManager.LoadScene("GameSL");
    }

    public void ChangeSceneFC()
    {
        SceneManager.LoadScene("GameFC");
    }
}
