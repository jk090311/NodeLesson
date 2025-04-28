using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using XNode;

public class SimpleDialogV2 : BaseNode
{
	[Input] public string entry;
	[Output] public string exit;

	[TextArea(7, 20)]
	public string dialogText;
	public Sprite BackgroundImage;
	public Sprite ActorImage;
	public BgMusic BackgroundMusic;
	public bool SlideInActor;

	public override string getDialogText()
	{
		return dialogText;
	}

	public override Sprite getSprite()
	{
		return BackgroundImage;
	}

	public override Sprite getSpriteActor()
	{
		if (ActorImage == null)
		{
			return null;
		}
		return ActorImage;
	}
	public override BgMusic getBgMusic()
	{
		return BackgroundMusic;
	}
	public override bool getSlideInActor()
	{
		return SlideInActor;
	}
}
