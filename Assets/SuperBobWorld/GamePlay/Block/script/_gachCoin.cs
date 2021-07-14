using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _gachCoin : MonoBehaviour
{
    // Start is called before the first frame update
    bool kt = true;
    float tocdonay = 4f;
    float donay = 0.5f;
    public float soCoin=8;
    Vector3 VtBanDau;
    Transform vitricha;
    [SerializeField]
    private BoxCollider2D boxGach;
    [SerializeField]
    private GameObject Item;
   

    private void Awake()
    {

        VtBanDau = transform.localPosition;
        vitricha = this.transform;
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.tag == "player" && collision.contacts[0].normal.y >0  )
        {
            _gachnaylen();
            if (Item != null)
            {


                if (Item.tag == "coin")
                {
                    StartCoroutine(CoinEat());
                }
                else StartCoroutine(ItemEat());
            }
            if (soCoin == 1)
            {
                GameObject KhoiRong = (GameObject)Instantiate(Resources.Load("gachrong"));
                KhoiRong.transform.SetParent(vitricha);
                KhoiRong.transform.localPosition = new Vector2(0, 0);
                boxGach.enabled = false;
                kt = false;
            }

            PanelLevel.instance.diem += 100;
            soCoin--;
            
        }
    }
    void _gachnaylen()
    {
        if (kt)
        {
            StartCoroutine(nay());
            
        }
    }
    IEnumerator nay()
    {
        while (true)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + tocdonay * Time.deltaTime,transform.localPosition.z);
            if (transform.localPosition.y > VtBanDau.y + donay) break;
            yield return null;
        }
        while (true)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - tocdonay * Time.deltaTime,transform.localPosition.z);
            if (transform.localPosition.y < VtBanDau.y)
            {
                transform.localPosition = VtBanDau;
               
                break;
            }
            yield return null;
        }

    }
    IEnumerator ItemEat()
    {
        while (Item.transform.position.y < this.transform.position.y+0.8f)
        {
            Item.transform.position = new Vector2(Item.transform.position.x, Item.transform.position.y + Time.deltaTime*2f);
            yield return new WaitForEndOfFrame();
        }
        //yield return null;
    }
    IEnumerator CoinEat()
    {
        Vector3 TdCoin;
        TdCoin = Item.transform.position;
        while (Item.transform.position.y < this.transform.position.y + 1.2f)
        {
            Item.transform.position = new Vector2(Item.transform.position.x, Item.transform.position.y + Time.deltaTime*2f);
            yield return new WaitForEndOfFrame();
        }
        PlayerPrefs.SetInt("CountCoin", PlayerPrefs.GetInt("CountCoin") + 1);
        Item.SetActive(false);
        Item.transform.position = TdCoin;
        Item.SetActive(true);
        //yield return null;
        
    }
}
