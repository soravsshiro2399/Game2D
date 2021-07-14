using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    [SerializeField]
    private Button btChar, btCharOn, btSkill, btSkillOn, btBullet, btBulletOn;
    [SerializeField]
    private GameObject panelChar, panelSkill, panelBullet,panelStore;

    public void _btChar()
    {
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

    public void _btSkill()
    {
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

    public void _btBullet()
    {
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
    public void _btExit()
    {
        panelStore.SetActive(false);
        Time.timeScale = 1;
    }

}
