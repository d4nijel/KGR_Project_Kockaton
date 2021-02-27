using System.Collections;
using UnityEngine;
public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public Transform player;
    public GameObject explotion;
    public GameObject blockPrefab;
    public GameObject blockPrefab2;
    public GameObject[] blokovi;

    void OnControllerColliderHit(ControllerColliderHit collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;

            Vector3 n = new Vector3(0, 0, 0);

            Instantiate(explotion, player.position + n, Quaternion.identity);

            FindObjectOfType<AudioManager>().Play("Explosion");

            FindObjectOfType<GameManager>().EndGame();
        }

        if (collisionInfo.collider.name == "PUJH")
        {
            Destroy(collisionInfo.gameObject);

            StartCoroutine(PowerUpJumpHigher());
        }

        if (collisionInfo.collider.name == "PUTW")
        {

            Destroy(collisionInfo.gameObject);

            StartCoroutine(PowerUpThroughWalls());
        }
    }

    public void DisableEnableCollision(string tag, GameObject obj1, GameObject obj2, bool disable = true)
    {
        if (disable)
        {
            obj1.GetComponent<BoxCollider>().isTrigger = true;
            obj1.GetComponent<Rigidbody>().useGravity = false;

            obj2.GetComponent<BoxCollider>().isTrigger = true;
            obj2.GetComponent<Rigidbody>().useGravity = false;

            blokovi = GameObject.FindGameObjectsWithTag(tag);

            foreach (GameObject blok in blokovi)
            {
                blok.GetComponent<BoxCollider>().isTrigger = true;
                blok.GetComponent<Rigidbody>().useGravity = false;
            }
        }
        else
        {
            obj1.GetComponent<BoxCollider>().isTrigger = false;
            obj1.GetComponent<Rigidbody>().useGravity = true;

            obj2.GetComponent<BoxCollider>().isTrigger = false;
            obj2.GetComponent<Rigidbody>().useGravity = true;

            blokovi = GameObject.FindGameObjectsWithTag(tag);

            foreach (GameObject blok in blokovi)
            {
                blok.GetComponent<BoxCollider>().isTrigger = false;
                blok.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }

    IEnumerator PowerUpThroughWalls()
    {
        FindObjectOfType<AudioManager>().Play("PowerUp");

        DisableEnableCollision("Obstacle", blockPrefab, blockPrefab2);

        yield return new WaitForSeconds(5);

        FindObjectOfType<AudioManager>().Play("Click");

        DisableEnableCollision("Obstacle", blockPrefab, blockPrefab2, false);

    }

    IEnumerator PowerUpJumpHigher()
    {
        FindObjectOfType<AudioManager>().Play("PowerUp");
        GetComponent<PlayerMovement>().SetJumpSpeed(4);
        yield return new WaitForSeconds(5);
        FindObjectOfType<AudioManager>().Play("Click");
        GetComponent<PlayerMovement>().SetJumpSpeed(0);
    }
}
