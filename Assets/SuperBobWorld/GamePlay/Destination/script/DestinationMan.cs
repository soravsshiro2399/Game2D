using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationMan : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 ViTriDes;
    BoxCollider2D BoxDesti;
    private void Awake()
    {
        BoxDesti = GetComponent<BoxCollider2D>();
        ViTriDes = transform.position;
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
            BoxDesti.enabled = false;

            // cong diem 
            PanelLevel.instance.diem += 1500;

            // Keo co xuong

            StartCoroutine(KeoCo());
        }
        

       }
    IEnumerator KeoCo()
    {
         while (transform.position.y> ViTriDes.y-2.5f)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - Time.deltaTime * 3f);
            yield return new WaitForEndOfFrame();
        }
    
         yield return null;
    }
 }

