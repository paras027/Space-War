using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject laser;
    public GameObject explosion;
    public float firerate = 0.90f;
    public float nextfire = 0.0f;
    public bool tripleshot=false;
    public bool speedboost = false;

    public int live = 3;
    // Start is called before the first frame update
    void Start()
    {
        transform.position=new Vector3 (0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        movement();

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            if(Time.time > nextfire)
            {
                if (tripleshot == true)
                {
                    Instantiate(laser, transform.position + new Vector3(0, 1.22f, 0), Quaternion.identity);
                    Instantiate(laser, transform.position + new Vector3(0.79f, -0.19f, 0), Quaternion.identity);
                    Instantiate(laser, transform.position + new Vector3(-0.81f, -0.24f, 0), Quaternion.identity);
                    nextfire = Time.time + firerate;
                }
                else
                {
                    Instantiate(laser, transform.position + new Vector3(0, 1.22f, 0), Quaternion.identity);
                    nextfire = Time.time + firerate;
                }
                
            }
           
        }
    }

    void movement()
    {
        float horizontalmove = Input.GetAxis("Horizontal");
        float verticalmove = Input.GetAxis("Vertical");
        if (speedboost == true)
        {
            transform.Translate(Vector3.right * Time.deltaTime * horizontalmove * speed *2);
            transform.Translate(Vector3.up * Time.deltaTime * verticalmove * speed * 2);
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * horizontalmove * speed);
            transform.Translate(Vector3.up * Time.deltaTime * verticalmove * speed);
        }

        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -3.796253f)
        {
            transform.position = new Vector3(transform.position.x, -3.796253f, 0);
        }
        else if (transform.position.x > 9.678761f)
        {
            transform.position = new Vector3(-9.678761f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.718427f)
        {
            transform.position = new Vector3(9.718427f, transform.position.y, 0);
        }
    }
    
    public void poweron()
    {
        tripleshot = true;
        StartCoroutine(powerDown());
    }
    public IEnumerator powerDown()
    {
        yield return new WaitForSeconds(5.0f);
        tripleshot = false;
    }

    public void speedbooston()
    {
        speedboost = true;
        StartCoroutine(speedBoostDown());
    }

    public IEnumerator speedBoostDown()
    {
        yield return new WaitForSeconds(5.0f);
        speedboost = false;
    }
    public void damage()
    {
        live--;
        if(live<1)
        {
            Instantiate(explosion,transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
