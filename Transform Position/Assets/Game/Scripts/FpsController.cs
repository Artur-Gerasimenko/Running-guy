using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FpsController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Text;
    public int fps { get; private set; }
    public float time { get; private set; } = default;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowFPS();
    }
    private void ShowFPS()
    {
        fps = (int)(1 / Time.unscaledDeltaTime);
        if(time <= 0)
        {
            time = 1;
            TextFPS();
        }
        time -= 1 * Time.deltaTime;
    }
    private void TextFPS()
    {
        Text.text = fps.ToString();
    }
}
