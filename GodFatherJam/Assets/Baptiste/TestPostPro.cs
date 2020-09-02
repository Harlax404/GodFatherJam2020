using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TestPostPro : MonoBehaviour
{
    [SerializeField]
    private float PPIntesity;

    private Vignette PPVignette;

    void Start()
    {
        PostProcessVolume volume = gameObject.GetComponent<PostProcessVolume>();
        //volume.profile.TryGetSettings<Vignette>(out );
        PPVignette = volume.profile.GetSetting<Vignette>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            PPIntesity += 0.01f;
        }

        UpdatePostProcess(PPIntesity);
    }

    private void UpdatePostProcess(float ModifIntensity)
    {
        PPVignette.intensity.value = ModifIntensity;

        // Set tous les bails en fonction de l'intensité
    }
}
