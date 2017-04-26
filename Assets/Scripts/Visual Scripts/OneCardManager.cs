using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Holds references for all my card information
public class OneCardManager : MonoBehaviour {

    public CardAsset cardAsset;
    public OneCardManager PreviewManager;
    [Header("Text Component References")]
    public Text nameText;
    public Text manaCostText;
    public Text descriptionText;
    public Text healthText;
    public Text attackText;
    [Header("Image References")]
    public Image cardTopRibbonImage;
    public Image cardLowRibbonImage;
    public Image cardGraphicImage;
    public Image cardBodyImage;
    public Image cardFaceFrameImage;
    public Image cardFaceGlowImage;
    public Image cardBackGlowImage;

    void Awake() {
        if (cardAsset != null)
            ReadCardFromAsset();
    }

    private bool canBePlayedNow = false;
    public bool CanBePlayedNow {
        get {
            return canBePlayedNow;
        }

        set {
            canBePlayedNow = value;

            cardFaceGlowImage.enabled = value;
        }
    }

    public void ReadCardFromAsset() {
        // Generating Cards
        // Apply Card Colour
        if (cardAsset.characterAsset != null) {
            cardBodyImage.color = cardAsset.characterAsset.classCardTint;
            cardFaceFrameImage.color = cardAsset.characterAsset.classCardTint;
            cardTopRibbonImage.color = cardAsset.characterAsset.classRibbonsTint;
            cardLowRibbonImage.color = cardAsset.characterAsset.classRibbonsTint;
        }
        else {
            //cardBodyImage.color = GlobalSettings.Instance.CardBodyStandardColor;
            cardFaceFrameImage.color = Color.white;
            //cardTopRibbonImage.color = GlobalSettings.Instance.cardRibbonsStandardColor;
            //cardLowRibbonImage.color = GlobalSettings.Instance.cardRibbonsStandardColor;
        }
        // Add Card Name
        nameText.text = cardAsset.name;
        // Add Mana Cost
        manaCostText.text = cardAsset.manaCost.ToString();
        // Add Description
        descriptionText.text = cardAsset.description;
        // Add Card Image
        cardGraphicImage.sprite = cardAsset.cardImage;

        if (cardAsset.maxHealth != 0) {
            // This is a minion card
            attackText.text = cardAsset.attack.ToString();
            healthText.text = cardAsset.maxHealth.ToString();
        }

        if (PreviewManager != null) {
            // This is a card, not a preview
            // Preview GameObject will have OneCardManager as well, but PreviewManager should be null there
            PreviewManager.cardAsset = cardAsset;
            PreviewManager.ReadCardFromAsset();
        }
    }
}
