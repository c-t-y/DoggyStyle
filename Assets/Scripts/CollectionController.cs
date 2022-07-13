using UnityEngine;


public class CollectionController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController.collectedAmount++;
            //make object disappear once picked up
            Destroy(gameObject);
        }
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyController>().Death();
        }
    }
}
