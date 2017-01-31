﻿using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Side_0Image : MonoBehaviour {

	Image _image;
	LinkedList<Sprite> _list;
	void Start () {		
		_image = GetComponent<Image> ();
		_list = new LinkedList<Sprite> (Resources.LoadAll ("Images", typeof(Sprite)).Cast<Sprite>());
        GetImageName();
    }

	public void NextImage()
	{	
		if (_list.Find (_image.sprite).Next == null) {           
			_image.sprite = _list.First.Value;
		} else {
			_image.sprite = _list.Find (_image.sprite).Next.Value;
		}
        GetImageName();
    }

    public void GetImageName()
    {
        if (LocalRecords.myPresident.Exists(x => x.ImageName == _image.sprite.name))
        {
            GameObject.Find("Canvas/Button_SelectOrBuy/Text").GetComponent<Text>().text = "выбрать";
        }
        else
        {
            GameObject.Find("Canvas/Button_SelectOrBuy/Text").GetComponent<Text>().text = "купить";
        }
    }
}
