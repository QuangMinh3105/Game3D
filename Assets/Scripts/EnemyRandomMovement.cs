using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;

    Vector3 targetPosition;

    public float minSpeed;
    public float maxSpeed;

    float speed;

    public float secondsToMaxDifficulty;



    void Start()
    {
        targetPosition = GetRandomPosition();
    }


    void Update()
    {
        Vector3 temp = transform.localScale;
        if ((Vector3)transform.position != targetPosition)
        {
            //if (transform.position.x > targetPosition.x)
            //{
            //    temp.x = -1f;
            //}
            //else
            //{
            //    temp.x = 1f;
            //}
            transform.localScale = temp;
            speed = Mathf.Lerp(minSpeed, maxSpeed, GetDiffcultyPercent());
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            targetPosition = GetRandomPosition();
        }

    }
    Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);
        return new Vector3(randomX, 0.2f ,randomZ);
    }

    float GetDiffcultyPercent()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);
    }
}
