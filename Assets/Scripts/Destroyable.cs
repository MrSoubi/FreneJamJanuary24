using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;
using NUnit.Framework.Interfaces;

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

        experiencePoints = rank * rank;

        if (materials.Count == 0)
        {
            materials.Add(meshRenderer.material);
        }
    }

    public void OnHit(int damage)
    {
        if (rank <= GameManager.GetRank())
        {
            hitPoints -= damage;

            UpdateTexture();

            if (hitPoints <= 0)
            {
                Demolish();
            }
        }
    }

    private void UpdateTexture()
    {
        int textureIndex = Mathf.FloorToInt(hitPoints / (maxHitPoints/materials.Count));
        meshRenderer.SetMaterials(new List<Material> { materials[textureIndex] });
    }

    public void Demolish()
    {
        GameManager.AddScore(experiencePoints);
        Destroy(gameObject);
    }

    public void SetOutline(int outline)
    {
        transform.GetComponent<Outline>().color = outline;
    }

    public int GetRank()
    {
        return rank;
    }
}
