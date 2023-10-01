using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //ref to player locaion
    public Transform target;
    //Engagement vars
    public float visibleDistance;
    public float engagementDistance;
    public float retreatDistance;
    public float movementSpeed;
    //the amount of time REQUIRED between shots
    public float shotTime;

    // refernce to the type of projectile the particular enemy uses
    public GameObject projectile;
    public float ProjectileForce = 10f;
    public float ShootingPointDist = 3f;

    //The actual remaining time needed to then shoot a projectile
    private float timetoshoot;
    //How many shots are shot in a given time (so we could set up burst attacks quickly for an enemy type)
    private float numberOfShots;
    private EnemyData.EnemyType enemyType;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        enemyType = this.GetComponent<EnemyData>().hostileType;
        timetoshoot = shotTime;


    }

    // Update is called once per frame
    void Update()
    {
        MovementCheck();

    }

    //Change the way the enemy acts based on what type it is. 
    public void MovementCheck()
    {
        if(enemyType == EnemyData.EnemyType.EldritchThrall)
        {
            ThrallV1MovementAndAttack();
        }
    }

    //This function handles the movement and spawns the thrall's attacks
    public void ThrallV1MovementAndAttack()
    {
        float distance = Vector2.Distance(transform.position, target.position);
        //if we see the enemy and he is too far to attack move towards him
        if (distance < visibleDistance && distance > engagementDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
        }
        //If we are close enough to attack, stop moving and begin attacking
        else if (distance < engagementDistance && distance > retreatDistance)
        {
            transform.position = this.transform.position;
            if (timetoshoot <= 0)
            {

                Instantiate(projectile, transform.position, Quaternion.identity);
                timetoshoot = shotTime;

            }

        }
        //if the player is getting too close run away a bit
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -movementSpeed * Time.deltaTime);
        }
        //keep the timer counting down
        timetoshoot -= Time.deltaTime;
    }


}