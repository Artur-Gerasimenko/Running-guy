using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void OnClickButtonScene(int NumberScene)
    {
        SceneManager.LoadScene(NumberScene);
    }
    public void OnContinue()
    {
        
        int ActiveNumberScene = SceneManager.GetActiveScene().buildIndex;
        if(ActiveNumberScene < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(ActiveNumberScene + 1);
        }else if(ActiveNumberScene == SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(0);
        }
    }
}
