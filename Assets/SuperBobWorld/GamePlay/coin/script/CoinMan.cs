using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMan : MonoBehaviour
{
    // Start is called before the first frame update
    PanelLevel TinhDiem;
    private void Awake()
    {
         TinhDiem  = GetComponent<PanelLevel>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<CharController>() != null)
        {
            //cong diem
            PanelLevel.instance.diem += 100;
            PlayerPrefs.SetInt("CountCoin", PlayerPrefs.GetInt("CountCoin") + 1);
            // xoa gameob
            Destroy(this.gameObject);
        }
    }
}
