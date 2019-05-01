using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public static GameObject can1;
    public static GameObject can2;
    public static GameObject can3;
    public static GameObject red;
    public static GameObject green;
    public static GameObject blue;
    public static GameObject chartreuse;
    public List<GameObject> canPrefabs = new List<GameObject>() { can1, can2, can3 };
    public List<GameObject> colorPrefabs = new List<GameObject>() { red, green, blue, chartreuse };

    private void Start()
    {
        InvokeRepeating("Spawn", 0f, 0.1f);
    }

    public void Spawn()
    {
        if (GameObject.Find("Can_1(Clone)") == null && GameObject.Find("Can_2(Clone)") == null && GameObject.Find("Can_3(Clone)") == null)
        {
            Instantiate(canPrefabs[Random.Range(0, canPrefabs.Count)], new Vector3(Random.Range(-20f, 20f), 0.5f, Random.Range(-20f, 20f)), Quaternion.identity);
        }
        else if (GameObject.Find("RedSphere(Clone)") == null && GameObject.Find("BlueSphere(Clone)") == null && GameObject.Find("GreenSphere(Clone)") == null && GameObject.Find("ChartreuseSphere(Clone)") == null)
        {
            Instantiate(colorPrefabs[Random.Range(0, colorPrefabs.Count)], new Vector3(Random.Range(-20f, 20f), 0.5f, Random.Range(-20f, 20f)), Quaternion.identity);
        }
    }
}
