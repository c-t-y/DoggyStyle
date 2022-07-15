using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyState
{
    Wander,
    Follow,
    Die
};


public class EnemyController : MonoBehaviour
{

    GameObject player;
    public EnemyState currState = EnemyState.Wander;

    public float range;
    public float speed;
    private bool chooseDir = false;
    private Vector3 randomDir;
    public float maxHealth;
    public float currentHealth;

    public HealthBar healthBar;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (currState == EnemyState.Wander)
        {
            Wander();
        }
        else if (currState == EnemyState.Follow)
        {
            Follow();
        }
        else if (currState == EnemyState.Die)
        {
            Death();
        }


        if (IsPlayerInRange(range) && currState != EnemyState.Die)
        {
            currState = EnemyState.Follow;
        }
        else if (!IsPlayerInRange(range) && currState != EnemyState.Die)
        {
            currState = EnemyState.Wander;
        }
    }

    private bool IsPlayerInRange(float range)
    {
        return Vector3.Distance(transform.position, player.transform.position) <= range;
    }
    private IEnumerator ChooseDirection()
    {
        chooseDir = true;
        yield return new WaitForSeconds(Random.Range(2f, 8f));
        randomDir = new Vector3(0, Random.Range(0, 360), 0);
        Quaternion nextRotation = Quaternion.Euler(randomDir);
        transform.rotation = Quaternion.Lerp(transform.rotation, nextRotation, Random.Range(0.5f, 2.5f));
        chooseDir = false;
    }
    void Wander()
    {
        if (!chooseDir)
        {
            StartCoroutine(ChooseDirection());
        }

        transform.position += -transform.right * speed * Time.deltaTime;
        if (IsPlayerInRange(range))
        {
            currState = EnemyState.Follow;
        }

    }
    void Follow()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
    public void Hit(float damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }
        if (currentHealth <= 0)
        {
            Death();
        }
    }
    public void Death()
    {
        Destroy(gameObject);
    }
}
