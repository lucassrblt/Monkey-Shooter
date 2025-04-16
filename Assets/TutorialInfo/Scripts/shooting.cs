using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject banana;
    public float shootingForce = 250f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("je suis lancé");

    }

    // Update is called once per frame
    void Update()
    {

            if (Input.GetKeyDown(KeyCode.Space))
            {

                GameObject projectile = Instantiate(banana,
                    transform.position, transform.rotation);
                Rigidbody rb = projectile.GetComponent<Rigidbody>();
                rb.AddForce((transform.forward + transform.up * 1f) * shootingForce);
                Debug.Log("je lance la banana");

            }
            
    }
}
