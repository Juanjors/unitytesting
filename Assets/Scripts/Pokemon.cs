using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon : MonoBehaviour
{
    private bool toLeft = true;
    private SpriteRenderer spriteR;
    public Sprite pokemon;

    // Start is called before the first frame update
    void Start()
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        InvokeRepeating("UpdatePokeball", 1, 0.7f);

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ITS HAPPENING");
        spriteR.sprite = pokemon;
    }


    void UpdatePokeball()
    {
        //transform.Rotate(new Vector3(0, 0, toLeft ? -40 : +40));
        toLeft = !toLeft;
        spriteR.flipX = toLeft;
    }
}
