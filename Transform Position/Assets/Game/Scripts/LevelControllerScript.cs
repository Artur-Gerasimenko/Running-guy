using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelControllerScript : MonoBehaviour
{
    private int LevelUnLock;
    public Button[] buttonsLevel;
    //public int[] NumbersLevelOnePlay;
    // Start is called before the first frame update
    private void Start()
    {
        LevelUnLock = PlayerPrefs.GetInt("Levels",defaultValue: 1);
       
       

        Debug.Log(LevelUnLock);
        for (int i = 0;i < buttonsLevel.Length; i++)
        {
            buttonsLevel[i].interactable = false;
        }
        
        for(int i = 0;i < LevelUnLock; i++)
        {
            
            buttonsLevel[i].interactable = true;
        }
    }
   /* private bool IsInteractable(int number)
    {
        for(int i = 0;i < NumbersLevelOnePlay.Length; i++)
        {
            if (number == NumbersLevelOnePlay[i]) return false;
            else if (number != NumbersLevelOnePlay[i]) continue;
        }
        return true;
    }*/
    // Update is called once per frame
    void Update()
    {
        
    }
}
