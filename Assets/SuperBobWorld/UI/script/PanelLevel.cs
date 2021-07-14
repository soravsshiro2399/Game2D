using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelLevel : MonoBehaviour
{
    public static PanelLevel instance;
    [SerializeField]
    private GameObject panelPause,panelHoiSinh,panelComplete;
    [SerializeField]
    Text level, TextCoin,Score;
    public GameObject LeVel, NhanVat;
    public int diem=0,CountLevel;
    public float KtTrangThaiNv=0;

    // Start is called before the first frame update
    private void Awake()
    {
        MakeInstance();
       
    }
    void Start()
    {
       
        Score.text = "" + diem;
        level.text = "" + (int)CountLevel;
        TextCoin.text = "" + PlayerPrefs.GetInt("CountCoin");
    }
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Score.text = "" + diem;
        TextCoin.text = "" + PlayerPrefs.GetInt("CountCoin");
        if (KtTrangThaiNv != 0)
        {
            switch (KtTrangThaiNv)
            {
                case 1:
                    // hien thi panelComplete
                    PlayerPrefs.SetInt("LevelUnlocks", PlayerPrefs.GetInt("LevelUnlocks") + 1);
                    StartCoroutine(PanComplete());
                    break;
                case 2:
                    // hien thi panlHoiSinh
                    PanHoiSinh();
                    break;
            }
        }
    }

    public void _btPause()
    {
        panelPause.SetActive(true);
        Time.timeScale = 0f;
    }
    IEnumerator PanComplete()
    {
        yield return new WaitForSeconds(1);
        panelComplete.SetActive(true);
    }
    void PanHoiSinh()
    {
       
        panelHoiSinh.SetActive(true);
        KtTrangThaiNv = 0;
    }
}
