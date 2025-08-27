using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    [SerializeField] private SkillScript[] ScriptsSkills;
    // Start is called before the first frame update
    public void Exit()
    {
        Application.Quit();
    }
    public void DeletAllKeys()
    {
        for(int i = 0;i < ScriptsSkills.Length; i++)
        {
            ScriptsSkills[i].DestroyAllKeys();
        }
        PlayerPrefs.DeleteAll();
    }
}