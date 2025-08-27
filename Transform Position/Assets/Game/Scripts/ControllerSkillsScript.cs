using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerSkillsScript : MonoBehaviour
{
    public Button[] ButtonSkills;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int GetIndex(string NameButton)
    {
        for(int i = 0;i < ButtonSkills.Length; i++)
        {
            if (ButtonSkills[i].name == NameButton) return i;
        }
        return -1;
    }
}
