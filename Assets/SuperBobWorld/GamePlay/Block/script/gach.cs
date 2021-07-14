using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gach : MonoBehaviour
{
    bool kt = true;
    float tocdonay = 4f;
    float donay = 0.5f;
    Vector3 VtBanDau;
   

    private void Awake()
    {

        VtBanDau = transform.localPosition;
        

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
        
       
            if (collision.gameObject.tag == "player" && collision.contacts[0].normal.y > 0)
            {
                CharController Nv = collision.gameObject.GetComponent<CharController>();
                
                if (Nv.capdo ==0)
                {
                    _gachnaylen();
                    kt = true;
                } else
                {
                _gachnaylen();
                Debug.Log("Pha Block");
                }
                    

            }
       
       
    }
    void _gachnaylen()
    {
        if (kt)
        {
            StartCoroutine(nay());
            kt = false;
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
}
