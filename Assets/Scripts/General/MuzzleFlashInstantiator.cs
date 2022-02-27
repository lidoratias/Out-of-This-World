using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlashInstantiator : MonoBehaviour
{

    public GameObject[] muzzleFlashes;
    private GameObject instantiatedMuzzleFlash;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1")){
            instantiatedMuzzleFlash = Instantiate(muzzleFlashes[Random.Range(0, 3)], transform.position, transform.rotation);
            instantiatedMuzzleFlash.transform.parent = transform;
            float size = Random.Range(0.6f, 0.9f);
            instantiatedMuzzleFlash.transform.localScale = new Vector3(size, size, size);
            Destroy(instantiatedMuzzleFlash, 0.02f);
        }/* else
        {
            if (Input.GetButton("up") || Input.GetButton("down") || Input.GetButton("left") || Input.GetButton("right"))
            {
                if (instantiatedMuzzleFlash != null)
                {
                    Destroy(instantiatedMuzzleFlash);
                    instantiatedMuzzleFlash = Instantiate(muzzleFlash, transform.position, transform.rotation);
                }
            }
            else
            {
                if (instantiatedMuzzleFlash != null)
                {
                    Destroy(instantiatedMuzzleFlash);
                }
            }
        }*/
    }
}
