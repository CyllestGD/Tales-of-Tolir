using UnityEngine;
using System.Collections;

public enum Heroes{Alyx, Nina, Erato, Brandon, Jordan, Paul}

public class CharacterAsset : ScriptableObject {
	public Heroes Hero;
	public string HeroName;
	public int maxHealth = 30;
	public string heroPowerName;
	public Sprite heroImage;
    public Sprite heroPowerIconImage;
    public Color32 classCardTint;
    public Color32 classRibbonsTint;
}
