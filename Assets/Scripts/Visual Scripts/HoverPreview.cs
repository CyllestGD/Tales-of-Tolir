using UnityEngine;
using System.Collections;
using DG.Tweening;

public class HoverPreview: MonoBehaviour
{
    // PUBLIC FIELDS
    public GameObject TurnThisOffWhenPreviewing;  // Won't turn anything off when null
    public Vector3 TargetPosition;
    public float TargetScale;
    public GameObject PreviewGameObject;
    public bool ActivateInAwake = false;

    // Private Fields
    private static HoverPreview currentlyViewing = null;

    // Properties w/ underlying Private Fields
    private static bool _PreviewsAllowed = true;
    public static bool PreviewsAllowed {
        get {
            return _PreviewsAllowed;}

        set  { 
            _PreviewsAllowed= value;
            if (!_PreviewsAllowed)
                stopAllPreviews();
        }
    }

    private bool _ThisPreviewEnabled = false;
    public bool ThisPreviewEnabled {
        get { return _ThisPreviewEnabled;}

        set { 
            _ThisPreviewEnabled = value;
            if (!_ThisPreviewEnabled)
                stopThisPreview();
        }
    }

    public bool OverCollider { get; set;}
 
    void Awake() {
        ThisPreviewEnabled = ActivateInAwake;
    }
            
    void OnMouseEnter() {
        OverCollider = true;
        if (PreviewsAllowed && ThisPreviewEnabled)
            previewThisObject();
    }
        
    void OnMouseExit() {
        OverCollider = false;

        if (!PreviewingSomeCard())
            stopAllPreviews();
    }

    void previewThisObject() {
        // Disable Past Preview
        stopAllPreviews();
        // Save Hover Preview
        currentlyViewing = this;
        // Enable Preview
        PreviewGameObject.SetActive(true);
        // Disable
        if (TurnThisOffWhenPreviewing!=null)
            TurnThisOffWhenPreviewing.SetActive(false); 
        // DOTween
        PreviewGameObject.transform.localPosition = Vector3.zero;
        PreviewGameObject.transform.localScale = Vector3.one;

        PreviewGameObject.transform.DOLocalMove(TargetPosition, 1f).SetEase(Ease.OutQuint);
        PreviewGameObject.transform.DOScale(TargetScale, 1f).SetEase(Ease.OutQuint);
    }

    void stopThisPreview() {
        PreviewGameObject.SetActive(false);
        PreviewGameObject.transform.localScale = Vector3.one;
        PreviewGameObject.transform.localPosition = Vector3.zero;
        if (TurnThisOffWhenPreviewing!=null)
            TurnThisOffWhenPreviewing.SetActive(true); 
    }

    private static void stopAllPreviews() {
        if (currentlyViewing != null){
            currentlyViewing.PreviewGameObject.SetActive(false);
            currentlyViewing.PreviewGameObject.transform.localScale = Vector3.one;
            currentlyViewing.PreviewGameObject.transform.localPosition = Vector3.zero;
            if (currentlyViewing.TurnThisOffWhenPreviewing!=null)
                currentlyViewing.TurnThisOffWhenPreviewing.SetActive(true); 
        }
         
    }

    private static bool PreviewingSomeCard() {
        if (!PreviewsAllowed)
            return false;

        HoverPreview[] allHoverBlowups = GameObject.FindObjectsOfType<HoverPreview>();

        foreach (HoverPreview hb in allHoverBlowups) {
            if (hb.OverCollider && hb.ThisPreviewEnabled)
                return true;
        }
        return false;
    }
}
