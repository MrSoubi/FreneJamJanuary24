using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    private int hitPoints;

    public GameObject explosion;

    public Material material1;
    public Material material2;
    public Material material3;

    // Start is called before the first frame update
    void Start()
    {
        hitPoints = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHit()
    {
        hitPoints--;
        
        switch (hitPoints)
        {
            case 2:
                GetComponent<MeshRenderer>().SetMaterials(new List<Material> { material2 });
                break;
            case 1:
                GetComponent<MeshRenderer>().SetMaterials(new List<Material> { material3 });
                break;
        }
        if (hitPoints <= 0)
        {
            Demolish();
        }
    }

    private void Demolish()
    {
        Instantiate<GameObject>(explosion);
        Destroy(gameObject);
    }
}
