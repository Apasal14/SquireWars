using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseManager : MonoBehaviour
{
    public GameObject prefab;
    GameObject horse1, horse2;
	Vector3 horse1Pos1, horse2Pos1, horse1Pos2, horse2Pos2;
    public float trainSpeed;
	private int directionProbability;

    void Start()
    {
        horse1Pos1 = new Vector3(30, 2f, -3.3f);
        horse2Pos1 = new Vector3(-30, 2f, 3.3f);

		horse1Pos2 = new Vector3(-30, 2f, -3.3f);
		horse2Pos2 = new Vector3(30, 2f, 3.3f);
        StartCoroutine(horseMechanics());

    }

    void Update()
    {
        restartHorses();
    }

    public IEnumerator horseMechanics()
    {
		trainSpeed = 20; //reset speed
		directionProbability = Random.Range (1, 11);
		trainSpeed += directionProbability; //add up to 10 extra speed points

		if (directionProbability < 5) {
			horse1 = Instantiate (prefab, horse1Pos1, Quaternion.identity);
			horse2 = Instantiate (prefab, horse2Pos1, Quaternion.identity);
		} else {
			horse1 = Instantiate (prefab, horse1Pos2, Quaternion.identity);
			horse2 = Instantiate (prefab, horse2Pos2, Quaternion.identity);
		}

        horse1.tag = "horse";
        Physics.IgnoreCollision(GameObject.Find("BOUNDARY_ARENA").GetComponent<Collider>(), horse1.GetComponent<Collider>());
        Physics.IgnoreCollision(GameObject.Find("BOUNDARY_ARENA (1)").GetComponent<Collider>(), horse1.GetComponent<Collider>());

        horse2.tag = "horse";
        Physics.IgnoreCollision(GameObject.Find("BOUNDARY_ARENA").GetComponent<Collider>(), horse2.GetComponent<Collider>());
        Physics.IgnoreCollision(GameObject.Find("BOUNDARY_ARENA (1)").GetComponent<Collider>(), horse2.GetComponent<Collider>());

		yield return new WaitForSeconds(Random.Range(1,3));


		if (directionProbability < 5) {
			horse1.transform.Rotate (new Vector3 (0, 180, 0));
			horse1.GetComponent<Rigidbody> ().velocity = -transform.right * trainSpeed;
			horse2.GetComponent<Rigidbody> ().velocity = transform.right * trainSpeed;
		} else {
			horse2.transform.Rotate (new Vector3 (0, 180, 0));
			horse2.GetComponent<Rigidbody> ().velocity = -transform.right * trainSpeed;
			horse1.GetComponent<Rigidbody> ().velocity = transform.right * trainSpeed;
		}
    }

    public void restartHorses()
    {
        if (horse1 != null && horse2 != null)
        {
			if (horse1.GetComponent<Transform>().position.x < -35 || horse2.GetComponent<Transform>().position.x < -35)
            {
                Destroy(horse1);
                Destroy(horse2);
                StartCoroutine(horseMechanics());
            }
        }
    }
}