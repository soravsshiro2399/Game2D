using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelComplete : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject panelLevel, panelSelect;
    [SerializeField]
    Text Score, HighScore;
    int i = 0;
    void Start()
    {
        if (PanelLevel.instance.diem > PlayerPrefs.GetInt("Level" + PanelLevel.instance.CountLevel.ToString()))
        {
            PlayerPrefs.SetInt("Level" + PanelLevel.instance.CountLevel.ToString(), PanelLevel.instance.diem);
        }
        HighScore.text = "" + PlayerPrefs.GetInt("Level" + PanelLevel.instance.CountLevel.ToString());
        Score.text = "" + i;
    }

    // Update is called once per frame
    void Update()
    {
     
        if (i<= PanelLevel.instance.diem)
        {
            Score.text = "" + i;
            TangI();
            
        }else Score.text = "" + PanelLevel.instance.diem;
    }
    void TangI()
    {
        i+=10;
    }
    public void GetCoin()
    {
        Debug.Log("Xem ADS nhan them Coin");

    }
    public void RestartGame()
    {
        PanelLevel.instance.diem = 0;
       
        Destroy(PanelLevel.instance.NhanVat);
        Destroy(PanelLevel.instance.LeVel);
        

        Camera.main.transform.position = new Vector3(0f, 0f, -10f);
        this.gameObject.SetActive(false);
        PanelLevel.instance.KtTrangThaiNv = 0;
        panelLevel.SetActive(true);
        //Load Pre Level
        PanelLevel.instance.LeVel = (GameObject)Instantiate(Resources.Load("KhoLeVel/LeVel" + PanelLevel.instance.CountLevel.ToString()));
        PanelLevel.instance.LeVel.transform.position = new Vector2(0f, 0f);

        PanelLevel.instance.NhanVat = (GameObject)Instantiate(Resources.Load("Character/Bob"));
        PanelLevel.instance.NhanVat.transform.position = new Vector2(0f, 0f);
    }
    public void NextLevel()
    {
        // Chuyen qua Level Ke Tiep
       
        PanelLevel.instance.CountLevel += 1;

        // Goi Ham Load Next Level
        NextLevel();
    }
    public void SelectLevel()
    {
        // destroy nhan vat, level
        Destroy(PanelLevel.instance.NhanVat);
        Destroy(PanelLevel.instance.LeVel);
        // setActive panlevel
        panelLevel.SetActive(false);
        //setActive panCom
        this.gameObject.SetActive(false);
        Camera.main.transform.position = new Vector3(0f, 0f, -10f);
        PanelLevel.instance.KtTrangThaiNv = 0;
        PanelLevel.instance.diem = 0;
        // Ve Man Hinh Select Level
        panelSelect.SetActive(true);
       
    }
    void NextLevel(int IndexLevel)
    {
        // destroy nhan vat, level
        Destroy(PanelLevel.instance.NhanVat);
        Destroy(PanelLevel.instance.LeVel);
        panelLevel.SetActive(true);
        this.gameObject.SetActive(false);
        PanelLevel.instance.diem = 0;
        PanelLevel.instance.CountLevel = IndexLevel;
        Camera.main.transform.position = new Vector3(0f, 0f, -10f);
        //Load Pre Level
        PanelLevel.instance.LeVel = (GameObject)Instantiate(Resources.Load("KhoLeVel/LeVel" + IndexLevel.ToString()));
        PanelLevel.instance.LeVel.transform.position = new Vector2(0f, 0f);

        PanelLevel.instance.NhanVat = (GameObject)Instantiate(Resources.Load("Character/Bob"));
        PanelLevel.instance.NhanVat.transform.position = new Vector2(0f, 0f);
    }
}
