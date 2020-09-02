using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TestPostPro : MonoBehaviour
{
    private float PPIntesity;
    [SerializeField]
    private float VignetteMod = 1;
    [SerializeField]
    private float FieldMod = 250;
    [SerializeField]
    private float BloomMod = 25;
    [SerializeField]
    private float MaxIntensity = 1;

    private Vignette PPVignette;
    private DepthOfField PPField;
    private Bloom PPBloom;

    void Start()
    {
        PostProcessVolume volume = gameObject.GetComponent<PostProcessVolume>();
        PPVignette = volume.profile.GetSetting<Vignette>();
        PPField = volume.profile.GetSetting<DepthOfField>();
        PPBloom = volume.profile.GetSetting<Bloom>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && PPIntesity < MaxIntensity)
        {
            PPIntesity += 0.01f;
            UpdatePostProcess(PPIntesity);
        }
    }

    private void UpdatePostProcess(float ModifIntensity)
    {
        PPVignette.intensity.value = ModifIntensity * VignetteMod;
        PPField.focalLength.value = ModifIntensity * FieldMod;
        PPBloom.intensity.value = ModifIntensity * BloomMod;
    }
}
