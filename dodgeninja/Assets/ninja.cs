using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class ninja : MonoBehaviour
{
    public Image hp;
    float health = 3f;
    float healthn = 3f;
    public GameObject panel;
    public Rigidbody rb;
    public Animator animator;
    public bool onGround = true;

    
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>();

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "danger")
        {
            healthn -= 1f;
            hp.fillAmount = healthn / health;
            
            if (healthn <= 0)
            {
                Time.timeScale = 0.0f;
                panel.SetActive(true);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Plane")
        {
            onGround = true;
        }
    }
    // Update is called once per frame
    void Update()
    {

        float pozisyon = Mathf.Clamp(transform.position.x, -7.5f, 7.5f);
        transform.position = new Vector2(pozisyon,transform.position.y);

        if (Input.GetKeyDown(KeyCode.UpArrow)&& onGround)
        {
            animator.SetTrigger("Jump");
            rb.AddForce(new Vector3(0,5,0),ForceMode.Impulse);
            onGround = false;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            
        }
       
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            animator.SetBool("Run",true);
         
           
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetBool("Run", false);
            animator.SetBool("Idle", true);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {

            transform.Translate(3 * Time.deltaTime, 0, 0,Space.World);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0f, 270f, 0f);
            animator.SetBool("Run", true);

        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetBool("Run", false);
            animator.SetBool("Idle", true);
            
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-3 * Time.deltaTime, 0, 0, Space.World);
        }
    }
    
}
