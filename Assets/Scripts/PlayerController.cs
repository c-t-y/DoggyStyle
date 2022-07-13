using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;
    new Rigidbody rigidbody;
    public TextMeshProUGUI collectedText;
    public static int collectedAmount = 0;

    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float fireRate = 1f;
    public bool allowFire = true;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        //Physics.IgnoreCollision(bulletPrefab.GetComponent<Collider>(), GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {

        //movement input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        rigidbody.velocity = new Vector3(horizontal * speed, 0, vertical * speed);


        //shooting input
        if (Input.GetKeyDown(KeyCode.UpArrow) && allowFire == true)
        {
            //StartCoroutine(Shoot("up"));
            var bulletInstance = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody>().AddForce(Vector3.forward * bulletSpeed);

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            var bulletInstance = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody>().AddForce(Vector3.back * bulletSpeed);

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            var bulletInstance = Instantiate(bulletPrefab, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody>().AddForce(Vector3.left * bulletSpeed);

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            var bulletInstance = Instantiate(bulletPrefab, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody>().AddForce(Vector3.right * bulletSpeed);

        }



        collectedText.text = "Items Collected: " + collectedAmount;
    }

    //IEnumerator Shoot(string direction)
    //{
    //    allowFire = false;
    //    if (direction == "up")
    //    {
    //        var bulletInstance = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), Quaternion.identity);
    //        bulletInstance.GetComponent<Rigidbody>().AddForce(Vector3.forward * bulletSpeed);
    //    }
    //    yield return new WaitForSeconds(fireRate);
    //    allowFire = true;

    //}



}
