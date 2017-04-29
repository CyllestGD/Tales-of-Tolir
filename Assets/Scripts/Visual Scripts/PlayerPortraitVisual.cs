using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerPortraitVisual : MonoBehaviour {
    // TODO : get ID from players when game starts
    //public GameObject Explosion;
    public CharacterAsset charAsset;
    [Header("Text Component References")]
    //public Text NameText;
    public Text HealthText;
    [Header("Image References")]
    public Image heroPowerIconImage;
    public Image portraitImage;

    public void ApplyLookFromAsset() {
        HealthText.text = charAsset.maxHealth.ToString();
        heroPowerIconImage.sprite = charAsset.heroPowerIconImage;
        portraitImage.sprite = charAsset.heroImage;
    }

    public void TakeDamage(int amount, int healthAfter) {
        if (amount > 0) {
            //DamageEffect.CreateDamageEffect(transform.position, amount);
            HealthText.text = healthAfter.ToString();
        }
    }

    public void Explode() {/*
        Instantiate(GlobalSettings.Instance.ExplosionPrefab, transform.position, Quaternion.identity);
        Sequence s = DOTween.Sequence();
        s.PrependInterval(2f);
        s.OnComplete(() => GlobalSettings.Instance.GameOverCanvas.SetActive(true));
    */}

    void Awake() {
        if (charAsset != null)
            ApplyLookFromAsset();
    }
}
