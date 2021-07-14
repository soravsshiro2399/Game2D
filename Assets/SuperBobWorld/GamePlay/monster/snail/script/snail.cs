using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snail : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D mybody;
    float xMin,xMax;
    
    float snailSpeed = 3f;
    public Animator anim;

    private Vector3 localScale,Posi;
    [SerializeField]
    private BoxCollider2D BoxSnail;
    [SerializeField]
    private CircleCollider2D CirSnail;
    public float k = 5;
    bool facingRight = true,Kthurt =true,KtVc=false;
    float h;

    private void Awake()
    {
        localScale = transform.localScale;
        Posi = transform.localPosition;
        BoxSnail = GetComponent<BoxCollider2D>();
        CirSnail = GetComponent<CircleCollider2D>();
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
        if (Kthurt && !KtVc)
        {
            if (facingRight)
            {
                mybody.velocity = new Vector2(1 * snailSpeed, mybody.velocity.y);
            }
            else
            {
                mybody.velocity = new Vector2(-1 * snailSpeed, mybody.velocity.y);
            }
        } else if (!Kthurt && KtVc)
        {
            if (facingRight)
            {
                mybody.velocity = new Vector2(1 * snailSpeed, mybody.velocity.y);
            }
            else
            {
                mybody.velocity = new Vector2(-1 * snailSpeed, mybody.velocity.y);
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
        if (collision.gameObject.tag == "player" && collision.contacts[0].normal.y < 0 && Kthurt )
        {
           
            anim.SetBool("KtHurt",true);
            Kthurt = false;
        } 
        if (collision.gameObject.tag == "player" && collision.contacts[0].normal.y >= 0 && Kthurt)
        {
            Kthurt = false;
        } else if (collision.gameObject.tag == "player" && Kthurt == false && collision.contacts[0].normal.y < 0)
        {
            StartCoroutine(hurtMove());
            KtVc = true;
        }
        if ((collision.gameObject.GetComponent<BulletControll>() != null))
        {
           
            StartCoroutine(RuaDie());
            Destroy(collision.gameObject);

            PanelLevel.instance.diem += 100;
        }
       
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (transform.position.y - Posi.y > 0.3f && collision.gameObject.tag=="grounded")
        {
            StartCoroutine(RuaDie());
            PanelLevel.instance.diem += 100;
        }
    }
    void _checkFace()
    {
        if (h > xMax)
        {     
            facingRight = false;
            
        } else if (h < xMin)
        {
          
            facingRight = true;
            
        }
        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
        {
            localScale.x *= -1;
        }

        transform.localScale = localScale;
    }
    IEnumerator hurtMove()
    {
        
        yield return new WaitForSeconds(5);
        Kthurt = true;
        KtVc = false;
        anim.SetBool("KtHurt", false);
    }
    IEnumerator RuaDie()
    {
        mybody.AddForce(Vector2.up * 100f);
        localScale.y *= -1;
        transform.localScale = localScale;
        BoxSnail.enabled = false;
        CirSnail.enabled = false;
        KtVc = true;
       
        yield return new WaitForSeconds(4);
        Destroy(this.gameObject);
    }
}
