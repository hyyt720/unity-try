using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityfX : MonoBehaviour
{
    private SpriteRenderer sr;
    
    [Header("flash FX")]
    [SerializeField] private Material hitMat;
    [SerializeField] private Material originalMat;

    private void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        originalMat = sr.material;

    }

    private IEnumerator FlashFX()
    {
        sr.material = hitMat;
        //更改材料时长
        yield return new WaitForSeconds(.2f);

        sr.material = originalMat;
    }
}
