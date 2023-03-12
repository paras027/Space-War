using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_Up : MonoBehaviour
{
    public float speed = 3.0f;
    public int powerID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player p = other.GetComponent<Player>();
        if (powerID == 0)
        {
            p.poweron();
        }
        else if(powerID==1)
        {
            p.speedbooston();
        }
        Destroy(this.gameObject);
    }
}
