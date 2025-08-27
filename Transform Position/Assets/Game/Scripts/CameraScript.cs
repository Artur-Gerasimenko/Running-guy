using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float distance;
    public float SpeedPositionX;
    public float DistanceMoveX;

    private GameObject Player;
    private PlayerMovement PlayerScript;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        PlayerScript = Player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Player.transform.position.z - transform.position.z > distance)
        {
            transform.position += new Vector3(0, 0, PlayerScript.Speed * Time.fixedDeltaTime);
        }
        else if (Player.transform.position.z - transform.position.z < distance)
        {
            transform.position += new Vector3(0, 0, -PlayerScript.Speed * Time.fixedDeltaTime);
        }
        transform.position = Vector3.Lerp(transform.position, new Vector3(Player.transform.position.x, transform.position.y, transform.position.z), SpeedPositionX * Time.fixedDeltaTime);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, distance);
    }
}
