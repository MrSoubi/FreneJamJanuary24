using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{

    [SerializeField] private int maxHitPoints;
    [SerializeField] private int experiencePoints;
    [SerializeField] private int rank;

    [SerializeField] private List<Material> materials;

    private int hitPoints;

    //private GameObject explosion;

    // Components
    private MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        hitPoints = maxHitPoints;

        if (materials.Count == 0)
        {
            materials.Add(meshRenderer.material);
        }
    }

    public void OnHit(GameObject dragon, int damage)
    {
        hitPoints -= damage;

        UpdateTexture();

        if (hitPoints <= 0)
        {
            Demolish(dragon);
        }
    }

    private void UpdateTexture()
    {
        int textureIndex = Mathf.FloorToInt(hitPoints / (maxHitPoints/materials.Count));
        Debug.Log(materials.Count + " materials, " + hitPoints + " hit points left");
        meshRenderer.SetMaterials(new List<Material> { materials[textureIndex] });
    }

    private void Demolish(GameObject dragon)
    {
        //var localExplosion = Instantiate<GameObject>(explosion);
        //localExplosion.transform.position = transform.position;

        //dragon.GetComponent<DragonController>().Grow(1.2f);

        Destroy(gameObject);
    }
}
