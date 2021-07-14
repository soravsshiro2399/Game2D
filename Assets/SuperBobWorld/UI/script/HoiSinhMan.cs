using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoiSinhMan : MonoBehaviour
{
    [SerializeField]
    GameObject panelGameOver;
    [SerializeField]
    Text CountTime;
    float OnTime = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OnTime <= 0)
        {
            NoThank();
        } else CountDown();
        CountTime.text = "" + (int)OnTime;
        
    }
    public void Revive()
    {
        // Hoi sinh Tai Ckech point
    }
    public void NoThank()
    {
        this.gameObject.SetActive(false);
        panelGameOver.SetActive(true);
    }
    void CountDown()
    {
        OnTime -= Time.deltaTime;
    }
}
