using UnityEngine;
using System.Collections;

public enum Heroes{Alyx, Brandon, Jordan, Paul}

public class CharacterAsset : ScriptableObject {
	public Heroes Hero;
	public string HeroName;
	public int maxHealth = 30;
	public string heroPowerName;
	public Sprite avatarImage;
    public Sprite heroPowerIconImage;
    public Sprite avatarBGImage;
    public Sprite heroPowerBGImage;
    public Color32 avatarBGTint;
    public Color32 heroPowerBGTint;
    public Color32 classCardTint;
    public Color32 classRibbonsTint;
}
