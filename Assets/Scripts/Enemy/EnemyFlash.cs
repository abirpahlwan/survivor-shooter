using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlash : MonoBehaviour
{
    private const float flashDuration = 0.2f; // Duration of the flash effect in seconds
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Flash()
    {
        spriteRenderer.color = Color.red;
        StartCoroutine(ResetMaterial());
    }

    private IEnumerator ResetMaterial()
    {
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = Color.white;
    }
}
