using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class AbilityCheckNode : BaseNode {
	
	[Input] public string entry;
	[Output] public string success;
	[Output] public string failure;

	[TextArea (7, 20)]
	public string dialogText;
	public Sprite dialogImage;
	public float difficultyCheckValue;
	public Ability abilityCheck;

	public override string getDialogText()
	{
		return dialogText;
	}

	public override Sprite getSprite()
	{
		return dialogImage;
	}
    public override Ability getAbility()
    {
        return abilityCheck;
    }
	public override float getDC()
	{
		return difficultyCheckValue;
	}

}