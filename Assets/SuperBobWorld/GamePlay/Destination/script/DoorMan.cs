using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMan : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 ViTriDoor;
    private void Awake()
    {
        ViTriDoor = transform.position;
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
        if (collision.gameObject.GetComponent<CharController>() !=null )
        {
            StartCoroutine(ThuCua());
            
        }
    }
    IEnumerator ThuCua()
    {
        while(transform.position.y < ViTriDoor.y +0.7f)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + Time.deltaTime * 1f);
            yield return new WaitForEndOfFrame();
        }
        
        yield return null;
    }
}
