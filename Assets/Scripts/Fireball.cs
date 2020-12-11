using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    float timer;
    public GameObject fireAnimation;
    public Sprite burningTree;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       // Destroy(gameObject);

        if (other.tag == "Flammable")
        {
            Vector3 rightPosition = other.transform.position;
            rightPosition.y = rightPosition.y - 0.94f;
            other.GetComponent<SpriteRenderer>().sprite = burningTree;
            GameObject fire = Instantiate(fireAnimation, rightPosition, Quaternion.identity);

            Destroy(other.gameObject, 1f);
            Destroy(gameObject);
            Destroy(fire, 1.5f);

        }
        if (other.tag == "Lantern")
        {
            other.GetComponent<Lantern>().Ignite();
            Destroy(gameObject);
        }

        //Destroy(gameObject);
    }

    IEnumerator DestroyTree(Collider other, GameObject fire) {
        yield return new WaitForSeconds(3);
    }
}
