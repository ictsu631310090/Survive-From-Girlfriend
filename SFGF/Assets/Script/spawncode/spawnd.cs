using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnd : MonoBehaviour
{

    GameObject cloneD;
    public GameObject outDfabs;
    int Drandom;
    public Transform Dout1;
    public Transform Dout2;
    public Transform Dout3;
    public float SpawndDogTime = 5.0f;
    float SpawndDogTimeMax = 5.0f;
    public static int NumDog = 5;
    public int MaxNumDog = 5;

    public void GenerateD()
    {
        Drandom = Random.Range(1, 4);
        cloneD = Instantiate(outDfabs);
        if (Drandom == 1)
        {
            cloneD.transform.position = Dout1.position;
        }
        else if (Drandom == 2)
        {
            cloneD.transform.position = Dout2.position;
        }
        else if (Drandom == 3)
        {
            cloneD.transform.position = Dout3.position;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        NumDog = MaxNumDog;
        NumDog = NumDog - 1;
        SpawndDogTime = SpawndDogTimeMax;
        GenerateD();
    }

    // Update is called once per frame
    void Update()
    {
        if (NumDog > 0)
        {
            SpawndDogTime -= Time.deltaTime;
        }
        if (SpawndDogTime <= 0)
        {
            if (NumDog > 0)
            {
                GenerateD();
                NumDog--;
            }
            SpawndDogTime = SpawndDogTimeMax;
        }
        Debug.Log(NumDog);
    }
}
