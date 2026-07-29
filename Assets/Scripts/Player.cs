using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    GameObject currentFloor;
    [SerializeField] int Hp;
    // Start is called before the first frame update
    void Start()
    {
        Hp = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(moveSpeed*Time.deltaTime, 0 ,0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-moveSpeed*Time.deltaTime, 0 ,0);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Normal")
        {
            if(other.contacts[0].normal == new Vector2(0f,1f))
            {
                Debug.Log("撞到了第一种阶梯");
                currentFloor = other.gameObject;
                ModifyHp(1);
            }
        }
        else if(other.gameObject.tag == "Nails")
        {
            if(other.contacts[0].normal == new Vector2(0f,1f))
            {
                Debug.Log("撞到了第二种阶梯");
                currentFloor = other.gameObject;
                ModifyHp(-3);
            }
        }
        else if(other.gameObject.tag == "Ceiling")
        {
            if(other.contacts[0].normal == new Vector2(0f,1f))
            {
                Debug.Log("撞到天花板");
                currentFloor.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "DeathLine")
        {
            Debug.Log("撞到了死亡线");
        }
    }

    void ModifyHp(int num)
    {
        Hp += num;
        if(Hp > 10)
        {
            Hp = 10;
        }
        else if(Hp <= 0)
        {
            Hp = 0;
        }
    }
}
