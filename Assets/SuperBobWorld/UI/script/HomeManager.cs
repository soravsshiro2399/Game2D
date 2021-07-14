using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeManager : MonoBehaviour
{
    // khoi tao prefab chua coin
    public const string COUNTCOIN = "CountCoin";
    public const string LEVELUNLOCKS = "LevelUnlocks";
    [SerializeField]
    private GameObject panelSetting,panelStore,panelChooseLevel;
    [SerializeField]
    private Button btMusicOn, btMusicOff, btSoundOn, btSoundOff;
    [SerializeField]
    private Button btChar, btCharOn, btSkill, btSkillOn, btBullet, btBulletOn;
    [SerializeField]
    private GameObject panelChar, panelSkill, panelBullet,panelHome;
    [SerializeField] Button btShopChar, btShopBullet;
    [SerializeField]
    Text SoCoin;
    float delay = 3f;
    float currentTime = 3f;
    bool kt = true;
    private void Awake()
    {
        //if (!PlayerPrefs.HasKey("IsGameStartedForTheFirstTime"))
       // {
            PlayerPrefs.SetInt(COUNTCOIN, 0);
            PlayerPrefs.SetInt(LEVELUNLOCKS, 1);
           // PlayerPrefs.SetInt("IsGameStartedForTheFirstTime", 0);
       // }
    }
    void Start()
    {
        SoCoin.text = "" + PlayerPrefs.GetInt("CountCoin");
    }

   
    void Update()
    {
        SoCoin.text = "" + PlayerPrefs.GetInt("CountCoin");
        currentTime -= Time.deltaTime;
        if (currentTime < 0)
        {
            if (kt)
            {
                btShopChar.gameObject.SetActive(false);
                btShopBullet.gameObject.SetActive(true);
                currentTime = delay;
                kt = false;
            } else
            {
                btShopChar.gameObject.SetActive(true);
                btShopBullet.gameObject.SetActive(false);
                currentTime = delay;
                kt = true;
            }
           
        }
    }

    // panel home
    public void _btPlay()
    {
        panelChooseLevel.SetActive(true);
        panelHome.SetActive(false);
    }
    public void _btFreeCoin()
    {

    }
    public void _btShopBullet()
    {
        Time.timeScale = 0;
        panelStore.SetActive(true);
        btChar.gameObject.SetActive(true);
        btCharOn.gameObject.SetActive(false);
        btSkill.gameObject.SetActive(true);
        btSkillOn.gameObject.SetActive(false);
        btBullet.gameObject.SetActive(false);
        btBulletOn.gameObject.SetActive(true);

        panelBullet.SetActive(true);
        panelChar.SetActive(false);
        panelSkill.SetActive(false);


    }
    public void _btShopChar()
    {
        Time.timeScale = 0;
        panelStore.SetActive(true);
        btChar.gameObject.SetActive(false);
        btCharOn.gameObject.SetActive(true);
        btSkill.gameObject.SetActive(true);
        btSkillOn.gameObject.SetActive(false);
        btBullet.gameObject.SetActive(true);
        btBulletOn.gameObject.SetActive(false);

        panelBullet.SetActive(false);
        panelChar.SetActive(true);
        panelSkill.SetActive(false);
    }
    public void _btCoin()
    {
        Time.timeScale = 0;
        panelStore.SetActive(true);
        btChar.gameObject.SetActive(true);
        btCharOn.gameObject.SetActive(false);
        btSkill.gameObject.SetActive(false);
        btSkillOn.gameObject.SetActive(true);
        btBullet.gameObject.SetActive(true);
        btBulletOn.gameObject.SetActive(false);

        panelBullet.SetActive(false);
        panelChar.SetActive(false);
        panelSkill.SetActive(true);
    }


    // panel setting
    public void _btSetting()
    {
        panelSetting.SetActive(true);
    }
  
    public void _btExit()
    {
        panelSetting.SetActive(false);
       
    }
    public void _btMusicOn()
    {
        btMusicOn.gameObject.SetActive(false);
        btMusicOff.gameObject.SetActive(true);


        // thuc hien tat nhac
    }
    public void _btMusicOff()
    {
        btMusicOff.gameObject.SetActive(false);
        btMusicOn.gameObject.SetActive(true);

        // Thuc hien mo nhac
    }

    public void _btSoundOn()
    {
        btSoundOn.gameObject.SetActive(false);
        btSoundOff.gameObject.SetActive(true);


        // thuc hien tat am thanh

    }
    public void _btSoundOff()
    {
        btSoundOff.gameObject.SetActive(false);
        btSoundOn.gameObject.SetActive(true);

        // thuc hien bat am thanh

    }

    public void _btFace()
    {
        // load fb
    }
    public void _btRate()
    {
        //load rate
    }

    


    
}
