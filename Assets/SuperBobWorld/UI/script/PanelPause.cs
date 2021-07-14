using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelPause : MonoBehaviour
{
    [SerializeField]
    private GameObject panelPause;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void _btResume()
    {
        panelPause.SetActive(false);
        Time.timeScale = 1f;
    }
    public void _btRestart()
    {
        // load laij level
    }
    public void _btSeclecLevel()
    {
        // load panel select level
    }
}
