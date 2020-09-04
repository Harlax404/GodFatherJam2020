using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TestPostPro : MonoBehaviour
{
    public float PPIntesity;
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

    [SerializeField]
    private AudioClip PoliceSirens;
    [SerializeField]
    private AudioClip HeartBeat;
    private AudioSource JudgementSource;

    void Start()
    {
        GameObject VolumeHolder = Camera.main.gameObject;

        PostProcessVolume volume = VolumeHolder.GetComponent<PostProcessVolume>();
        PPVignette = volume.profile.GetSetting<Vignette>();
        PPField = volume.profile.GetSetting<DepthOfField>();
        PPBloom = volume.profile.GetSetting<Bloom>();

        JudgementSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow) && PPIntesity < MaxIntensity)
        {
            PPIntesity += 0.01f;
            IshIsh();
        }

        if (Input.GetKey(KeyCode.DownArrow) && PPIntesity >= 0)
        {
            PPIntesity -= 0.01f;
            IshIsh();
        }
    }

    public void IshIsh()
    {
        //Debug.Log("rentre dans ISH ISH");
        UpdatePostProcess(PPIntesity);
        PlaySirens(PPIntesity);
    }

    private void UpdatePostProcess(float ModifIntensity)
    {
        PPVignette.intensity.value = ModifIntensity * VignetteMod;
        PPField.focalLength.value = ModifIntensity * FieldMod;
        PPBloom.intensity.value = ModifIntensity * BloomMod;
    }

    private void PlaySirens(float ModifIntensity)
    {
        JudgementSource.volume = ModifIntensity; 

        if(!JudgementSource.isPlaying)
        {
            //JudgementSource.PlayOneShot(PoliceSirens);
            JudgementSource.PlayOneShot(HeartBeat);
        }

        if(JudgementSource.isPlaying && PPIntesity == 0)
        {
            JudgementSource.Stop();
        }
    }
}
