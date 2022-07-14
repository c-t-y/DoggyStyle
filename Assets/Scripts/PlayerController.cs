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
    public float fireRate;
    private bool allowFire;


    // Start is called before the first frame update
    void Start()
    {
        allowFire = true;
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //movement input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        rigidbody.velocity = new Vector3(horizontal * speed, 0, vertical * speed);


        //shooting input
        if (Input.GetKey(KeyCode.UpArrow) && allowFire == true)
        {

            Shoot("up");
            allowFire = false;
            StartCoroutine(FireCooldown());

        }
        if (Input.GetKey(KeyCode.DownArrow) && allowFire == true)
        {
            Shoot("down");
            allowFire = false;
            StartCoroutine(FireCooldown());

        }
        if (Input.GetKey(KeyCode.LeftArrow) && allowFire == true)
        {
            Shoot("left");
            allowFire = false;
            StartCoroutine(FireCooldown());

        }
        if (Input.GetKey(KeyCode.RightArrow) && allowFire == true)
        {
            Shoot("right");
            allowFire = false;
            StartCoroutine(FireCooldown());

        }




        collectedText.text = "Items Collected: " + collectedAmount;
    }

    void Shoot(string direction)
    {
        if (direction == "up")
        {

            var bulletInstance = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody>().AddForce(Vector3.forward * bulletSpeed);


        }
        if (direction == "down")
        {
            var bulletInstance = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody>().AddForce(Vector3.back * bulletSpeed);
        }
        if (direction == "left")
        {
            var bulletInstance = Instantiate(bulletPrefab, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody>().AddForce(Vector3.left * bulletSpeed);
        }
        if (direction == "right")
        {
            var bulletInstance = Instantiate(bulletPrefab, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody>().AddForce(Vector3.right * bulletSpeed);
        }
    }

    public IEnumerator FireCooldown()
    {
        yield return new WaitForSeconds(fireRate);
        allowFire = true;
    }


    //IEnumerator Shoot(string direction)
    //{
    //    if (direction == "up")
    //    {
    //        var bulletInstance = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), Quaternion.identity);
    //        bulletInstance.GetComponent<Rigidbody>().AddForce(Vector3.forward * bulletSpeed);
    //        yield return new WaitForSeconds(1f);
    //    }
    //    if (direction == "down")
    //    {
    //        var bulletInstance = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), Quaternion.identity);
    //        bulletInstance.GetComponent<Rigidbody>().AddForce(Vector3.back * bulletSpeed);
    //        yield return new WaitForSeconds(1f);
    //    }
    //    if (direction == "left")
    //    {
    //        var bulletInstance = Instantiate(bulletPrefab, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity);
    //        bulletInstance.GetComponent<Rigidbody>().AddForce(Vector3.left * bulletSpeed);
    //        yield return new WaitForSeconds(1f);
    //    }
    //    if (direction == "right")
    //    {
    //        var bulletInstance = Instantiate(bulletPrefab, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), Quaternion.identity);
    //        bulletInstance.GetComponent<Rigidbody>().AddForce(Vector3.right * bulletSpeed);
    //        yield return new WaitForSeconds(1f);
    //    }

    //}



}
