using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(transform.up * 1500f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
