using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    public GameObject HowToPlayUI;
    int PHowToPlay = 1;
    public GameObject P1;
    public GameObject P2;
    public GameObject P3;

    public void openHowToPlay()
    {
        HowToPlayUI.SetActive(true);
    }
    public void NPHowToPlay()
    {
        if (PHowToPlay < 3)
        {
            PHowToPlay++;
        }
    }
    public void BPHowToPlay()
    {
        if (PHowToPlay >= 1)
        {
            PHowToPlay--;
        }
    }
    public void closeHowToPlay()
    {
        HowToPlayUI.SetActive(false);
        PHowToPlay = 1;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PHowToPlay == 1)
        {
            P1.SetActive(true);
            P2.SetActive(false);
            P3.SetActive(false);
        }
        if (PHowToPlay == 2)
        {
            P1.SetActive(false);
            P2.SetActive(true);
            P3.SetActive(false);
        }
        if (PHowToPlay == 3)
        {
            P1.SetActive(false);
            P2.SetActive(false);
            P3.SetActive(true);
        }
    }
}
