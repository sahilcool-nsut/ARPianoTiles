using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehavior : MonoBehaviour
{
    [SerializeField] float tileSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * tileSpeed);
    }
    
    IEnumerator SelfDestruct(){
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
