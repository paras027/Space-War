using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject enemyExplosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);

        if(transform.position.y < -6.15)
        {
            transform.position = new Vector3(Random.Range(-7.2f, 6.35f), 6.08f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "laser")
        {
            Destroy(other.gameObject);
            Instantiate(enemyExplosion,transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if(other.tag == "Player")
        {
            Player p= other.GetComponent<Player>();
            p.damage();
            Instantiate(enemyExplosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
