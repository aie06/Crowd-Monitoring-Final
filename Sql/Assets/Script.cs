﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data.SqlClient;
using QRCoder;
using QRCoder.Unity;
using System;
using System.Windows;
using TMPro;


public class Script : MonoBehaviour
{
    public Image img;
    public TMP_InputField id;

    public void generateQR()
    {
        QRCodeGenerator qr = new QRCodeGenerator();
        QRCodeData qRCodeData = qr.CreateQrCode(id.text, QRCodeGenerator.ECCLevel.H);
        UnityQRCode code = new UnityQRCode(qRCodeData);
        Texture2D text = code.GetGraphic(4);
       
        byte[] arr = text.ImgToBytes();
        Texture2D result = arr.BytesToImg();
        Sprite convert = Sprite.Create(text, new Rect(0,0,text.width,text.height), Vector2.one * .5f);
        img.sprite = convert;
        Debug.Log(BitConverter.ToString(arr));
    }
}
