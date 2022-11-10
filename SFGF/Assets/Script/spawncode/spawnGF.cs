using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnGF : MonoBehaviour
{
    GameObject cloneGF;
    public GameObject outGFfabs;
    int GFrandom;
    public Transform gf1out;
    public Transform gf2out;
    public Transform gf3out;
    public Transform gf4out;
    public Transform gf5out;
    public Transform gf6out;
    public Transform gf7out;
    public Transform gf8out;
    public float time = 30.0f;
    float maxtime;
    public AudioClip sfxshespawn;
    public AudioSource sfxAudioSource_shespawn;

    // Start is called before the first frame update
    public void GenerateGF()
    {
        GFrandom = Random.Range(1, 9);
        cloneGF = Instantiate(outGFfabs);
        if (GFrandom == 1)
        {
            cloneGF.transform.position = gf1out.position;
        }
        else if (GFrandom == 2)
        {
            cloneGF.transform.position = gf2out.position;
        }
        else if (GFrandom == 3)
        {
            cloneGF.transform.position = gf3out.position;
        }
        else if (GFrandom == 4)
        {
            cloneGF.transform.position = gf4out.position;
        }
        else if (GFrandom == 5)
        {
            cloneGF.transform.position = gf5out.position;
        }
        else if (GFrandom == 6)
        {
            cloneGF.transform.position = gf6out.position;
        }
        else if (GFrandom == 7)
        {
            cloneGF.transform.position = gf7out.position;
        }
        else if (GFrandom == 8)
        {
            cloneGF.transform.position = gf8out.position;
        }
        sfxAudioSource_shespawn.PlayOneShot(sfxshespawn);
    }
    void Start()
    {
        maxtime = time;
    }

    // Update is called once per frame
    void Update()
    {
        if (FieldOfView1.canSeePlayer == false)
        {
            time -= Time.deltaTime;
        }
        if (FieldOfView1.canSeePlayer == true)
        {
            time = maxtime;
        }
        if (time <= 0.0f)
        {
            Destroy(cloneGF, 0.25f);
            GenerateGF();
            time = maxtime;
        }
    }
}
