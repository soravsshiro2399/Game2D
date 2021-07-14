using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseLevelManager : MonoBehaviour
{
    [SerializeField] 
    private Button btShopChar, btShopBullet,btNext,btPrev;
    [SerializeField] 
    private GameObject panelChooseLevel,panelHome,panelLevel;
    [SerializeField]
    private GameObject[] panels;
    float delay = 3f;
    float currentTime = 3f;
    bool kt = true;
    private int dem = 0;
    [SerializeField]
    private Button[] ButtonOns;
    [SerializeField]
    private Button[] ButtonOffs;
    int LevelsUnlock;
   
    // Start is called before the first frame update
    void Start()
    {
        LevelsUnlock = PlayerPrefs.GetInt("LevelUnlocks");
        for (int i=0; i<ButtonOns.Length;i++)
        {
            ButtonOns[i].gameObject.SetActive( false);
            ButtonOffs[i].gameObject.SetActive(true);
        }
        for (int i=0; i<LevelsUnlock;i++)
        {
            ButtonOns[i].gameObject.SetActive(true);
            ButtonOffs[i].gameObject.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime < 0)
        {
            if (kt)
            {
                btShopChar.gameObject.SetActive(false);
                btShopBullet.gameObject.SetActive(true);
                currentTime = delay;
                kt = false;
            }
            else
            {
                btShopChar.gameObject.SetActive(true);
                btShopBullet.gameObject.SetActive(false);
                currentTime = delay;
                kt = true;
            }

        }
        if (dem == 0) { btPrev.gameObject.SetActive(false); }
        else btPrev.gameObject.SetActive(true);
        if (dem == panels.Length-1) { btNext.gameObject.SetActive(false); }
        else btNext.gameObject.SetActive(true);
        
    }
    public void LoadLevel(int IndexLevel)
    {
       
       
        panelChooseLevel.SetActive(false);
        panelLevel.SetActive(true);
        PanelLevel.instance.CountLevel = IndexLevel;
        PanelLevel.instance.diem = 0;
        //Load Pre Level
        PanelLevel.instance.LeVel = (GameObject)Instantiate(Resources.Load("KhoLeVel/LeVel" + IndexLevel.ToString()));
        PanelLevel.instance.LeVel.transform.position = new Vector2(0f,0f);

        PanelLevel.instance.NhanVat = (GameObject)Instantiate(Resources.Load("Character/Bob"));
        PanelLevel.instance.NhanVat.transform.position = new Vector2(0f,0f);

    }
    public void _bthome()
    {
        panelChooseLevel.SetActive(false);
        panelHome.SetActive(true);
    }

    public void _btNext()
    {
        dem++;
        for(int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }
        panels[dem].SetActive(true);
        // hien thi panel tiep
    }

    public void _btPrev()
    {
        dem--;
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }
        panels[dem].SetActive(true);

    }

}
