using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveObstructions : MonoBehaviour
{
    Material mat;
    public float dissolveSpeed;

    private void Start()
    {
        mat = GetComponentInParent<Renderer>().material;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            Debug.Log("Success");
            StartCoroutine(DissolveMaterial());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            Debug.Log("Success Exit");

            StartCoroutine(ShowMaterial());
        }
    }

    public IEnumerator DissolveMaterial()
    {
        float value = mat.GetFloat("_DissolvePercentage");
        while (value < 1)
        {
            value += dissolveSpeed * Time.deltaTime;
            mat.SetFloat("_DissolvePercentage", value);
            yield return null;
        }
        yield return null;
    }

    public IEnumerator ShowMaterial()
    {
        float value = mat.GetFloat("_DissolvePercentage");

        while (value > 0)
        {
            value -= dissolveSpeed * Time.deltaTime;
            mat.SetFloat("_DissolvePercentage", value);
            yield return null;
        }
        yield return null;
    }
}
