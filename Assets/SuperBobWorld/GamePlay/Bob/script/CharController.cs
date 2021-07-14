using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CharController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D mybody;

    [SerializeField]
    float runSpeed = 5f, roi = 5f;

    Vector3 localScale;
    Transform ViTri;
    [SerializeField]
    private Animator animator;
    public bool facingRight = true;
    bool ktCap = true,ktNhay=false,KtDie=false;
    private float h, j, DoTre = 0.09f;
    public float capdo = 0;
    [SerializeField]
    BoxCollider2D boxNv;
    [SerializeField]
    CircleCollider2D cirNv;
    private void Awake()
    {
        CameChecking();
        localScale = transform.localScale;
        mybody = GetComponent<Rigidbody2D>();
        animator = GetComponent< Animator >();
        boxNv = GetComponent<BoxCollider2D>();
        cirNv = GetComponent<CircleCollider2D>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        CameChecking();
        ViTri = this.transform;
        if (KtDie == false)
        {
            h = CrossPlatformInputManager.GetAxis("Horizontal");
            _playmove();
            if (CrossPlatformInputManager.GetButtonDown("Jump") && (mybody.velocity.y == 0))
            {
                _jump();

            }
           
            if (CrossPlatformInputManager.GetButtonDown("Shoot"))
            {
                if (capdo == 2)
                {
                    Shoot();
                }
                // nhieu truong hop de ban nua.
            }
        }
        if (ktNhay== true && mybody.velocity.y <= 0)
        {
            mybody.velocity += Vector2.up * Physics2D.gravity.y * (roi - 1) * Time.deltaTime;
        }
        

        if (ktCap)
        {
            switch (capdo)
            {
                case 0:
                   
                    StartCoroutine(marioNho());
                    break;
                case 1:
                    StartCoroutine(marioTo());
                    break;
                case 2:
                    StartCoroutine(marioDan());
                    break;
                default:
                    StartCoroutine(marioNho());
                    break;
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
    void _checkFace()
    {
        if (h>0)
        {
            facingRight = true;
        } else if (h<0)
            facingRight = false;
        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x >0) ) )
        {
            localScale.x  *= -1;
        }
        transform.localScale = localScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "grounded" && collision.contacts[0].normal.y>0)
        {
            animator.SetBool("KtJum", false);
            ktNhay = false;
            
        }
        if (collision.gameObject.tag =="energy")
        {
            if (capdo != 2)
            {
                capdo = 1;
               
            }
            ktCap = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "boom")
        {
            capdo = 2;
            ktCap = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "monster" && collision.contacts[0].normal.y <= 0)

        {
            if (capdo == 0)
            {
                animator.SetBool("KtDie", true);
                KtDie = true;


                StartCoroutine(marioDie());
            }
            else { capdo = 0;
                ktCap = true;
            }
           
        }
        if (collision.gameObject.GetComponent<DoorMan>() != null)
        {
            PanelLevel.instance.KtTrangThaiNv = 1;
        }
    }
   
    void _playmove()
    {
        if (h > 0)
        {
            mybody.velocity = new Vector2(h * runSpeed, mybody.velocity.y);
            animator.SetBool("KtRun", true);
        }
        else if (h < 0)
        {
            mybody.velocity = new Vector2(h * runSpeed, mybody.velocity.y);
            animator.SetBool("KtRun", true);
        }
        else
        {
            mybody.velocity = new Vector2(0, mybody.velocity.y);
            animator.SetBool("KtRun", false);
             
        }
    }
    void _jump()
    {
        mybody.AddForce(Vector2.up * 450f);
        
        animator.SetBool("KtJum", true);
        ktNhay = true;
      
    }
   
    void Shoot()
    {
        StartCoroutine(Fire());
    }
    IEnumerator marioNho()
    {
        ktCap = false;
        while (Math.Abs(localScale.x) > 1)
        {
            if (localScale.x > 0) localScale.x -= Time.deltaTime;
            else localScale.x += Time.deltaTime;
            if (localScale.y > 0) localScale.y -= Time.deltaTime;
            else localScale.y += Time.deltaTime;
            transform.localScale = localScale;
            yield return new WaitForEndOfFrame();
        }
        animator.SetLayerWeight(animator.GetLayerIndex("DangNho"), 1);
        animator.SetLayerWeight(animator.GetLayerIndex("DangTo"), 0);
        animator.SetLayerWeight(animator.GetLayerIndex("DangAnDan"), 0);
        yield return new WaitForSeconds(DoTre);
 
    }
    IEnumerator marioTo()
    {
        ktCap = false;
       
        while (Math.Abs(localScale.x) < 1.6)
        { 
            if (localScale.x > 0) localScale.x += Time.deltaTime;
            else localScale.x -= Time.deltaTime;
            if (localScale.y > 0) localScale.y += Time.deltaTime;
            else localScale.y -= Time.deltaTime;
            transform.localScale = localScale;
            yield return new WaitForEndOfFrame();
        }

        animator.SetLayerWeight(animator.GetLayerIndex("DangNho"), 0);
        animator.SetLayerWeight(animator.GetLayerIndex("DangTo"), 1);
        animator.SetLayerWeight(animator.GetLayerIndex("DangAnDan"), 0);
        yield return new WaitForSeconds(DoTre);
        animator.SetLayerWeight(animator.GetLayerIndex("DangNho"), 1);
        animator.SetLayerWeight(animator.GetLayerIndex("DangTo"), 0);
        animator.SetLayerWeight(animator.GetLayerIndex("DangAnDan"), 0);
        yield return new WaitForSeconds(DoTre);
        animator.SetLayerWeight(animator.GetLayerIndex("DangNho"), 0);
        animator.SetLayerWeight(animator.GetLayerIndex("DangTo"), 1);
        animator.SetLayerWeight(animator.GetLayerIndex("DangAnDan"), 0);
        yield return new WaitForSeconds(DoTre);
        animator.SetLayerWeight(animator.GetLayerIndex("DangNho"), 1);
        animator.SetLayerWeight(animator.GetLayerIndex("DangTo"), 0);
        animator.SetLayerWeight(animator.GetLayerIndex("DangAnDan"), 0);
        yield return new WaitForSeconds(DoTre);
        animator.SetLayerWeight(animator.GetLayerIndex("DangNho"), 0);
        animator.SetLayerWeight(animator.GetLayerIndex("DangTo"), 1);
        animator.SetLayerWeight(animator.GetLayerIndex("DangAnDan"), 0);
        yield return new WaitForSeconds(DoTre);
        animator.SetLayerWeight(animator.GetLayerIndex("DangNho"), 1);
        animator.SetLayerWeight(animator.GetLayerIndex("DangTo"), 0);
        animator.SetLayerWeight(animator.GetLayerIndex("DangAnDan"), 0);
        yield return new WaitForSeconds(DoTre);
        animator.SetLayerWeight(animator.GetLayerIndex("DangNho"), 0);
        animator.SetLayerWeight(animator.GetLayerIndex("DangTo"), 1);
        animator.SetLayerWeight(animator.GetLayerIndex("DangAnDan"), 0);
        yield return new WaitForSeconds(DoTre);
    }
    IEnumerator marioDan()
    {
        ktCap = false;
        while (Math.Abs(localScale.x) < 1.6)
        {
            if (localScale.x > 0) localScale.x += Time.deltaTime;
            else localScale.x -= Time.deltaTime;
            if (localScale.y > 0) localScale.y += Time.deltaTime;
            else localScale.y -= Time.deltaTime;
            transform.localScale = localScale;
            yield return new WaitForEndOfFrame();
        }
        animator.SetLayerWeight(animator.GetLayerIndex("DangNho"), 0);
        animator.SetLayerWeight(animator.GetLayerIndex("DangTo"), 0);
        animator.SetLayerWeight(animator.GetLayerIndex("DangAnDan"), 1);
        yield return new WaitForSeconds(DoTre);
        animator.SetLayerWeight(animator.GetLayerIndex("DangNho"), 1);
        animator.SetLayerWeight(animator.GetLayerIndex("DangTo"), 0);
        animator.SetLayerWeight(animator.GetLayerIndex("DangAnDan"), 0);
        yield return new WaitForSeconds(DoTre);
        animator.SetLayerWeight(animator.GetLayerIndex("DangNho"), 0);
        animator.SetLayerWeight(animator.GetLayerIndex("DangTo"), 0);
        animator.SetLayerWeight(animator.GetLayerIndex("DangAnDan"), 1);
        yield return new WaitForSeconds(DoTre);
        animator.SetLayerWeight(animator.GetLayerIndex("DangNho"), 1);
        animator.SetLayerWeight(animator.GetLayerIndex("DangTo"), 0);
        animator.SetLayerWeight(animator.GetLayerIndex("DangAnDan"), 0);
        yield return new WaitForSeconds(DoTre);
        animator.SetLayerWeight(animator.GetLayerIndex("DangNho"), 0);
        animator.SetLayerWeight(animator.GetLayerIndex("DangTo"), 0);
        animator.SetLayerWeight(animator.GetLayerIndex("DangAnDan"), 1);
        yield return new WaitForSeconds(DoTre);
        animator.SetLayerWeight(animator.GetLayerIndex("DangNho"), 1);
        animator.SetLayerWeight(animator.GetLayerIndex("DangTo"), 0);
        animator.SetLayerWeight(animator.GetLayerIndex("DangAnDan"), 0);
        yield return new WaitForSeconds(DoTre);
        animator.SetLayerWeight(animator.GetLayerIndex("DangNho"), 0);
        animator.SetLayerWeight(animator.GetLayerIndex("DangTo"), 0);
        animator.SetLayerWeight(animator.GetLayerIndex("DangAnDan"), 1);
        yield return new WaitForSeconds(DoTre);
    }

    IEnumerator marioDie()
    {
        mybody.velocity = new Vector3(0f, 0f,0f);
        yield return new WaitForSeconds(2);
        mybody.AddForce(Vector2.up * 200f);
        boxNv.enabled = false;
        cirNv.enabled = false;
        yield return new WaitForSeconds(2);

       
        PanelLevel.instance.KtTrangThaiNv = 2;

        
    }
    IEnumerator Fire()
    {
        
        GameObject BulletBan = (GameObject)Instantiate(Resources.Load("BulletBan"));
       
        Rigidbody2D BulletBody = BulletBan.GetComponent<Rigidbody2D>();
        if (facingRight)
        {
            BulletBan.transform.localPosition = new Vector2(ViTri.position.x + 0.8f, ViTri.position.y);
            BulletBody.velocity = new Vector2(1 * 8f, mybody.velocity.y);
        }
        else
        {
            BulletBan.transform.localPosition = new Vector2(ViTri.position.x - 0.8f, ViTri.position.y);
            BulletBody.velocity = new Vector2(-1 * 8f, mybody.velocity.y);

        }
        yield return null;
    }
    void CameChecking()
    {
        Vector3 vitriCam = Camera.main.transform.position;
        vitriCam.x = transform.position.x;
        if (vitriCam.x < 0) vitriCam.x = 0;
        if (vitriCam.x > 1000) vitriCam.x = 1000;
        Camera.main.transform.position = vitriCam;
        
    }
}
