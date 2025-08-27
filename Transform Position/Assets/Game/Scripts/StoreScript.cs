using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreScript : MonoBehaviour
{
    public GameObject Persone;
    public Button[] SkinButton;

    private SkinnedMeshRenderer PersoneSkin;
    private SkinScript scriptSkin;
    // Start is called before the first frame update
    void Start() {

        PersoneSkin = Persone.GetComponentInChildren<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < SkinButton.Length; i++)
        {

            scriptSkin = SkinButton[i].GetComponent<SkinScript>();
            if (PlayerPrefs.GetInt($"ActiveSkin{i}") == 1)
            {

                PersoneSkin.material = scriptSkin.Skin;
                LibraryScript.SkinPlayer = scriptSkin.Skin;
            }
        }
    }
    public int GetIndex(string nameButton)
    {
        for (int i = 0; i < SkinButton.Length; i++)
        {
            if(nameButton == SkinButton[i].name)
            {
                return i;
            }
        }
        return -1;
    }
    public void IsActiveSkin(int Index)
    {
        scriptSkin = SkinButton[Index].GetComponent<SkinScript>();
        for (int i = 0; i < SkinButton.Length; i++)
        {
            int number;
            PlayerPrefs.SetInt($"ActiveSkin{ i}", number = i != Index ? 0 : 1);
        }
    }
    public void GetActive(int index)
    {
        for(int i = 0;i < SkinButton.Length; i++)
        {
            SkinButton[i].GetComponent<SkinScript>().isActiveSkin = false;
        }
        SkinButton[index].GetComponent<SkinScript>().isActiveSkin = true;
    }
}
