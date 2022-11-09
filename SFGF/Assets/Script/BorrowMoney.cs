using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BorrowMoney : MonoBehaviour
{
    public GameObject RaedyBorrowMoney;
    public Slider BM;
    public int MaxBorrowMoney = 500;
    public static bool canBorrow = false;
    bool canBorrowF1 = false;
    bool canBorrowF2 = false;
    bool canBorrowF3 = false;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "friend")
        {
            RaedyBorrowMoney.SetActive(true);
            canBorrow = true;
            if (collider.gameObject.name == "friend" || collider.gameObject.name == "friend(Clone)")
            {
                canBorrowF1 = true;
            }
            if (collider.gameObject.name == "friend 2" || collider.gameObject.name == "friend 2(Clone)")
            {
                canBorrowF2 = true;
            }
            if (collider.gameObject.name == "friend 3" || collider.gameObject.name == "friend 3(Clone)")
            {
                canBorrowF3 = true;
            }
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "friend")
        {
            RaedyBorrowMoney.SetActive(false);
            canBorrow = false;
            if (collider.gameObject.name == "friend" || collider.gameObject.name == "friend(Clone)")
            {
                canBorrowF1 = false;
            }
            if (collider.gameObject.name == "friend 2" || collider.gameObject.name == "friend 2(Clone)")
            {
                canBorrowF2 = false;
            }
            if (collider.gameObject.name == "friend 3" || collider.gameObject.name == "friend 3(Clone)")
            {
                canBorrowF3 = false;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        RaedyBorrowMoney.SetActive(false);
        BM.maxValue = MaxBorrowMoney;
        BM.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q) && canBorrow == true)
        {
            BM.value += 5;
        }
        else if (BM.value >= 0)
        {
            BM.value -= 1;
        }
        if (BM.value == BM.maxValue )
        {
            if (canBorrowF1 == true && friendmoney._friendmoney > 0)
            {
                itemmanager.moneyhave += 50;
                friendmoney._friendmoney -= 50;
                BM.value = 0;
                RaedyBorrowMoney.SetActive(false);
                canBorrowF1 = false;
            }//ยืมเงินเพื่อนคนที่ 1
            if (canBorrowF2 == true && friendmoney2._friendmoney > 0)
            {
                itemmanager.moneyhave += 50;
                friendmoney2._friendmoney -= 50;
                BM.value = 0;
                RaedyBorrowMoney.SetActive(false);
                canBorrowF2 = false;
            }//ยืมเงินเพื่อนคนที่ 2
            if (canBorrowF3 == true && friendmoney3._friendmoney > 0)
            {
                itemmanager.moneyhave += 50;
                friendmoney3._friendmoney -= 50;
                BM.value = 0;
                RaedyBorrowMoney.SetActive(false);
                canBorrowF3 = false;
            }//ยืมเงินเพื่อนคนที่ 3
        }
    }
}
