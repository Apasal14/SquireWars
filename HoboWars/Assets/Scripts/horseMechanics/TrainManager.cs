using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainManager : MonoBehaviour
{
    public GameObject prefab;
    GameObject train1, train2;
    Vector3 train1Pos, train2Pos;
    public float trainSpeed;

    void Start()
    {
        train1Pos = new Vector3(20, 2f, -3.8f);
        train2Pos = new Vector3(-20, 2f, 4.1f);
        StartCoroutine(trainMechanics());       // Start the timer function StartCountdown() by using the StartCoroutine() function
        //StartCoroutine(train2Mechanics());       // Start the timer function StartCountdown() by using the StartCoroutine() function
    }

    void Update()
    {
        restartTrains();
    }

    public IEnumerator trainMechanics()
    {
        train1 = Instantiate(prefab, train1Pos, Quaternion.identity);
        train1.tag = "train";
        Physics.IgnoreCollision(GameObject.Find("wall (3)").GetComponent<Collider>(), train1.GetComponent<Collider>());
        Physics.IgnoreCollision(GameObject.Find("wall").GetComponent<Collider>(), train1.GetComponent<Collider>());
        //print("Train 1 Instantiated");

        train2 = Instantiate(prefab, train2Pos, Quaternion.identity);
        train2.tag = "train";
        Physics.IgnoreCollision(GameObject.Find("wall").GetComponent<Collider>(), train2.GetComponent<Collider>());
        Physics.IgnoreCollision(GameObject.Find("wall (3)").GetComponent<Collider>(), train2.GetComponent<Collider>());
        //print("Train 2 Instantiated");

        //yield return new WaitForSeconds(Random.Range(1, 10));
        yield return new WaitForSeconds(1);

        train1.GetComponent<Rigidbody>().velocity = -transform.right * trainSpeed;
        

        train2.GetComponent<Rigidbody>().velocity = transform.right * trainSpeed;
    }

    public void restartTrains()
    {
        if (train1 != null)
        {
            if (train1.GetComponent<Transform>().position.x < -20)
            {
                Destroy(train1);
                Destroy(train2);
                StartCoroutine(trainMechanics());
            }
        }
    }
}