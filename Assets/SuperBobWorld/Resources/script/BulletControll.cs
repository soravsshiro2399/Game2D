using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControll : MonoBehaviour
{
    // Start is called before the first frame update
    
    private float DesTime = 2f;
    Rigidbody2D mybody;
    private void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        Destroy(this.gameObject, DesTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        mybody.velocity += Vector2.up * Physics2D.gravity.y * (4 - 1) * Time.deltaTime;
        StartCoroutine(Dan());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    IEnumerator Dan()
    {
        yield return new WaitForSeconds(0.5f);
        if (mybody.velocity.y > 7f) mybody.velocity = new Vector2(mybody.velocity.x, 7f);
        if (mybody.velocity.y < -7f) mybody.velocity = new Vector2(mybody.velocity.x, -7f);
    }
}
