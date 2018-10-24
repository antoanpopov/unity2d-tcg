using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class PlayerPortraitVisual : MonoBehaviour {

    // TODO : get ID from players when game starts

    //public GameObject Explosion;
    public CharacterAsset charAsset;
    [Header("Text Component References")]
    //public Text NameText;
    public TMP_Text HealthText;
    [Header("Image References")]
    public Image HeroPowerIconImage;
    public Image HeroPowerBackgroundImage;
    public Image PortraitImage;
    public Image PortraitBackgroundImage;

    void Awake() {
        if(charAsset != null){
            ApplyLookFromAsset();
        }
    }

    public void ApplyLookFromAsset()
    {
        HealthText.text = charAsset.MaxHealth.ToString();
        HeroPowerIconImage.sprite = charAsset.HeroPowerIconImage;
       
        PortraitImage.sprite = charAsset.AvatarImage;
        


      

        if(charAsset.HeroPowerBGImage != null) {
            HeroPowerBackgroundImage.sprite = charAsset.HeroPowerBGImage;
            HeroPowerBackgroundImage.color = charAsset.HeroPowerBGTint;
        }

        if (charAsset.AvatarBGImage != null) {
            PortraitBackgroundImage.color = charAsset.AvatarBGTint;
            PortraitBackgroundImage.sprite = charAsset.AvatarBGImage;
        }

    }

    public void TakeDamage(int amount, int healthAfter)
    {
        if (amount > 0)
        {
            DamageEffect.CreateDamageEffect(transform.position, amount);
            HealthText.text = healthAfter.ToString();
        }
    }

    public void Explode()
    {
        Instantiate(GlobalSettings.Instance.ExplosionPrefab, transform.position, Quaternion.identity);
        Sequence s = DOTween.Sequence();
        s.PrependInterval(2f);
        s.OnComplete(() => GlobalSettings.Instance.GameOverCanvas.SetActive(true));
    }



}
