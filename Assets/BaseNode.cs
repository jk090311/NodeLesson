using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class BaseNode : Node {

	public virtual string getDialogText()
	{
		return "";
	}

	public virtual Sprite getSprite()
	{
		return null;
	}
	public virtual Ability getAbility()
	{
		return Ability.PERCEPTION;
	}
	public virtual float getDC()
	{
		return 10.0f;
	}
	public virtual Sprite getSpriteActor()
	{
		return null;
	}
	public virtual BgMusic getBgMusic()
	{
		return BgMusic.SUSPENSE;
	}
	public virtual bool getSlideInActor()
	{
		return false;
	}
}