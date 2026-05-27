using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockSallanma : MonoBehaviour
{
    [SerializeField] private string blockTag = "blok";
    [SerializeField] private float swayAngle = 6f;
    [SerializeField] private float swaySpeed = 1.8f;
    [SerializeField] private Vector3 swayAxis = Vector3.forward;

    private GameObject[] blocks;
    private Quaternion[] baseLocalRotations;

    void Start()
    {
        blocks = GameObject.FindGameObjectsWithTag(blockTag);
        baseLocalRotations = new Quaternion[blocks.Length];

        for (int i = 0; i < blocks.Length; i++)
        {
            if (blocks[i] != null)
            {
                baseLocalRotations[i] = blocks[i].transform.localRotation;
            }
        }
    }

    void Update()
    {
        // Ruzgardaki hafif sallanti gibi ileri-geri salinim.
        for (int i = 0; i < blocks.Length; i++)
        {
            if (blocks[i] != null)
            {
                float phaseOffset = i * 0.35f;
                float angle = Mathf.Sin(Time.time * swaySpeed + phaseOffset) * swayAngle;
                blocks[i].transform.localRotation =
                    baseLocalRotations[i] * Quaternion.AngleAxis(angle, swayAxis.normalized);
            }
        }
    }
}
