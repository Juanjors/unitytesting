using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float speed;
    public Image[] hearts;
    Animator walkAnimator;
    public int maxHealth;
    public int currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player started");
        this.walkAnimator = GetComponent<Animator>();
    }


    void Update()
    {
        this.Movement();
        this.UpdateHealth();
        if (Input.GetKeyDown(KeyCode.M))
        {
            Damaged();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (currentHealth < maxHealth)
            {
                currentHealth++;
            }
        }
    }

    void UpdateHealth()
    {
        for (int i = 0; i < maxHealth; i++)
        {
            GameObject heart = hearts[i].gameObject;
            heart.SetActive(currentHealth > i);
            
        }
    }

    void Damaged()
    {
        if (currentHealth >= 1)
        {
            currentHealth--;
        }
    }



    void Movement()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            this.walkAnimator.speed = 1;
            transform.Translate(0, speed * Time.deltaTime, 0);
            this.walkAnimator.SetInteger("direction", 1);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            this.walkAnimator.speed = 1;
            transform.Translate(0, -speed * Time.deltaTime, 0);
            this.walkAnimator.SetInteger("direction", 0);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.walkAnimator.speed = 1;
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            this.walkAnimator.SetInteger("direction", 2);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.walkAnimator.speed = 1;
            transform.Translate(speed * Time.deltaTime, 0, 0);
            this.walkAnimator.SetInteger("direction", 3);
            //transform.localScale = new Vector3((float)(transform.localScale.x + 0.001), (float)(transform.localScale.y + 0.001), (float)(transform.localScale.z + 0.001));
        }
        else
        {
            this.walkAnimator.speed = 0;
        }

        this.speed =  (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) ? 3 : 1;
    }
}

