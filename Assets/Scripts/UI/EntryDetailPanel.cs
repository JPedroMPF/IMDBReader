using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class EntryDetailPanel : MonoBehaviour
{
    public RawImage posterImage;
    RectTransform thisRectTrans;

    private void Start()
    {
        thisRectTrans = transform.GetComponent<RectTransform>();
        AnimateOut();
    }

    public void DownloadImage(string movieID)
    {
        //THIS WOULD BE A RELATED THUMB, DIDN FIND ANY DB I COULD DOWNLOAD FROM

        string url = "https://i.pinimg.com/originals/2d/9c/24/2d9c2451a85575c2c1010ce9e784c17c.jpg";
        StartCoroutine(DownloadThumbnail(url, posterImage));
        AnimateIn();
    }

    private void AnimateIn()
    {
        thisRectTrans.DOScale(1,0.7f).SetEase(Ease.OutCirc);
    }

    public void AnimateOut()
    {
        thisRectTrans.DOScale(0, 0.7f).SetEase(Ease.OutCirc);
    }

    protected IEnumerator DownloadThumbnail(string thumbnailURI, RawImage graphic)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(thumbnailURI);

        yield return www.SendWebRequest();

        while (!www.isDone)
        {
            yield return 0;
        }

        if (www.error == null)
        {
            Texture2D texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            graphic.texture = texture;
            

        }

        www.downloadHandler.Dispose();
        www.Dispose();
    }
}
