using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour
{
    public GameObject expEffect;


    public Mesh[] meshes;

    private int hitCount = 0;

    private Rigidbody rb;

    private MeshFilter meshFilter;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        meshFilter = GetComponent<MeshFilter>();
    }

    private void OnCollisionEnter(Collision coll)
    {
        if(coll.collider.CompareTag("BULLET"))
        {
            if(++hitCount == 3)
            {
                ExpBarrel();
            }
        }
    }

    private void ExpBarrel()
    {
        Instantiate(expEffect, transform.position, Quaternion.identity);

        rb.mass = 1.0f;

        rb.AddForce(Vector3.up * 1000.0f);


        GameObject effect = Instantiate(expEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2.0f);

        int idx = Random.Range(0, meshes.Length);

        meshFilter.sharedMesh = meshes[idx];
    }

    
}
