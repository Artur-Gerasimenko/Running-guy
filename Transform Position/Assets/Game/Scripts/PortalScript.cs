using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public GameObject Portal2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            other.transform.position = Portal2.transform.position;
            Camera.main.transform.position = Portal2.transform.position + new Vector3(0,10,0);
        }
    }
}
