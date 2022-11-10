using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class manumanager : MonoBehaviour
{
    public GameObject PauseUI;
    public GameObject CreditsUI;
    float time = 0.0f;
    Text timeText;

    public GameObject GameoverUI;
    public GameObject MerchantUI1;
    public GameObject MerchantUI2;
    public static bool OpenGameoverUI = false;
    public static bool OpenwinnerUI = false;
    public static bool M1UI = false;
    public static bool M2UI = false;

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1; //เวลาในเกมเดินต่อ
    }
    public void Manu() 
    {
        SceneManager.LoadScene(0);
    }
    public void openCreditsUI()
    {
        CreditsUI.SetActive(true);
    }
    public void closeCreditsUI()
    {
        CreditsUI.SetActive(false);
    }
    public void ResumeGame()
    {
        PauseUI.SetActive(false); //ปิดหน้าต่างหยุด
        Time.timeScale = 1; //เวลาในเกมเดินต่อ
        Cursor.visible = false;
    }
    public void RestarGame()
    {
        GameoverUI.SetActive(false);
        PauseUI.SetActive(false);
        time = 0.0f;
        Time.timeScale = 1;
        Cursor.visible = false;
        friendmoney._friendmoney = 50;
        friendmoney2._friendmoney = 50;
        friendmoney3._friendmoney = 50;
        itemmanager.moneyhave = 0;
        itemmanager.haveChocolate = false;
        itemmanager.haveDoll = false;
        itemmanager.haveWater = false;
        itemmanager.haveWater2 = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        FieldOfView1.canSeePlayer = false;
    }
    public void backgame()
    {
        SceneManager.LoadScene("Manu");
    }
    public void QuitGame()
    {
        Application.Quit(); // จะทำงานได้ต่อเมื่อเป็น .exe
    }
    // Start is called before the first frame update
    void Start()
    {
        OpenGameoverUI = false;
        OpenwinnerUI = false;
        PauseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        timeText = GetComponent<Text>();
        timeText.text = "time : " + time.ToString("f1");
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1)
        {
            PauseUI.SetActive(true); //แสดงหน้าต่างหยุด
            Time.timeScale = 0; //หยุดเวลาในเกม
            Cursor.visible = true;
            MerchantUI1.SetActive(false);
            MerchantUI2.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0)
        {
            ResumeGame();
        }

        if (OpenwinnerUI == true)
        {
            MerchantUI1.SetActive(false);
            MerchantUI2.SetActive(false);
            SceneManager.LoadScene("End");
        }
        if (OpenGameoverUI == true)
        {
            GameoverUI.SetActive(true);
            MerchantUI1.SetActive(false);
            MerchantUI2.SetActive(false);
        }
    }
}
