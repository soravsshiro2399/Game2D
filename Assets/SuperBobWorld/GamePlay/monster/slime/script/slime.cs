using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D mybody;
    float xMin, xMax;
    [SerializeField]
    private BoxCollider2D boxSlime;
    [SerializeField]
    private CircleCollider2D CirSlime;
    float snailSpeed = 3f;
    public Animator anim;
    private Vector3 localScale,Posi;
    public float k = 5;
    bool facingRight = false,ktDie=true;
   
    float h;
    private void Awake()
    {
        localScale = transform.localScale;
        Posi = transform.localPosition;
        boxSlime = GetComponent<BoxCollider2D>();
        CirSlime = GetComponent<CircleCollider2D>();
        xMax = Posi.x + k;
        xMin = Posi.x - k;
        mybody = GetComponent<Rigidbody2D>();
        
    }
    void Start()
    {

    }


    void Update()
    {

        h = mybody.transform.position.x;
        if (ktDie)
        {
            if (facingRight)
            {
                mybody.velocity = new Vector2(1 * snailSpeed, 0f);
            }
            else
            {
                mybody.velocity = new Vector2(-1 * snailSpeed,0f);
            }
        }

       


    }
    private void FixedUpdate()
    {
        
    }
    private void LateUpdate()
    {
        _checkFace();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player" && collision.contacts[0].normal.y < 0)
        {
            boxSlime.enabled = false; 
            anim.SetBool("KtDie", true);
            ktDie = false;

            PanelLevel.instance.diem += 100;
            StartCoroutine(TimeDestroy());
        }
        if (collision.gameObject.tag == "player" && collision.contacts[0].normal.y >= 0)
        {
            ktDie = false;
        }
        if ( (collision.gameObject.GetComponent<BulletControll>() != null ))
        {
            Destroy(collision.gameObject);
            PanelLevel.instance.diem += 100;
            StartCoroutine(Chet());
          
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (transform.position.y - Posi.y > 0.3f && collision.gameObject.tag == "grounded")
        {
            StartCoroutine(Chet());
            PanelLevel.instance.diem += 100;
        }
    }
    void _checkFace()
    {
        if (h > xMax)
        {
            facingRight = false;

        }
        else if (h < xMin)
        {

            facingRight = true;

        }
        if (((facingRight) && (localScale.x > 0)) || ((!facingRight) && (localScale.x < 0)))
        {
            localScale.x *= -1;
        }

        transform.localScale = localScale;
    }
    IEnumerator TimeDestroy()
    {
        yield return new WaitForSeconds(0.7f);
        Destroy(this.gameObject);
    }
    IEnumerator Chet()
    {
        mybody.AddForce(Vector2.up * 100f);
        localScale.y *= -1;
        transform.localScale = localScale;
        boxSlime.enabled = false;
        CirSlime.enabled = false;
        ktDie = false;
        yield return new WaitForSeconds(4);
        Destroy(this.gameObject);
    }
}
