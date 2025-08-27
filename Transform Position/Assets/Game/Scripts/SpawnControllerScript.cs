using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControllerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3[] position;
    public Quaternion[] rotate;
    public GameObject[] Objects;
    private GameObject[] OtherObjects;
    public float MinDistanceZ, MaxDistanceZ;
    public float distanceX, distanceY, distanceZ;
    protected float time;
    // Start is called before the first frame update
    void Start()
    {
        /*for (int i = 1; i < Objects.Length; i++)
        {
            Objects[i] = Instantiate(Objects[i], RandomPosition(Index: i),ObjectRotation(IndexObject: i));
            //Invoke("ObjectDestroy", .2f);
        }*/
        int Index = default;
        OtherObjects = new GameObject[Objects.Length];
        for (int i = 0; i < OtherObjects.Length; i++)
        {
            while (true)
            {
                Index = Random.Range(0, Objects.Length);
                if (Objects[Index] != null)
                {
                    break;
                }
            }
            OtherObjects[i] = Objects[Index];
            Objects[Index] = null;
            OtherObjects[i] = Instantiate(OtherObjects[i], RandomPosition(IndexDefaultObject: Index, IndexOtherObject: i),ObjectRotation(IndexObject: Index));
        }
    }

    private Vector3 RandomPosition(int IndexOtherObject,int IndexDefaultObject)
    {
        float distance = FindDistance(distanceZ);
        return new Vector3(
            Random.Range(transform.position.x - position[IndexDefaultObject].x, transform.position.x + position[IndexDefaultObject].x),
            transform.position.y + position[IndexDefaultObject].y,
            transform.position.z + distance * IndexOtherObject);
    }
    private Quaternion ObjectRotation(int IndexObject)
    {
        return new Quaternion(rotate[IndexObject].x, rotate[IndexObject].y, rotate[IndexObject].z,rotate[IndexObject].w);
    }
    private float FindDistance(float distance)
    {
        return distance / Objects.Length;
    }
    private void ObjectDestroy()
    {
        //Destroy(Object);
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, new Vector3(distanceX * 2, distanceY * 2, distanceZ * 2));
    }
}
