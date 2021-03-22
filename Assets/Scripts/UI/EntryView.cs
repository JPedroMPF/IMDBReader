using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EntryView : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Text movieTitle;
    public Text titleYear;
    public Text duration;
    public Text Genres;
    public Text CastInfo;

    public EntryDetailPanel entryDetailPanel;     
    
    public void SetDetailsPanel(EntryDetailPanel detailsPanel)
    {
        entryDetailPanel = detailsPanel;
    }

    public void SetMovieTitle(string movieTitleIn)
    {
        movieTitle.text = movieTitleIn;
    }

    public void SetTitleYear(string titleYearIn)
    {
        titleYear.text = titleYearIn;
    }
    public void SetDuration(string durationIn)
    {
        titleYear.text = durationIn;
    }
    public void SetGenres(string genresIn)
    {
        titleYear.text = genresIn;
    }
    public void SetCastInfo(string directorIn, string actor1NameIN, string actor2NameIn)
    {
        titleYear.text = "Directed by: " + directorIn + " With: " + actor1NameIN + " and " + actor2NameIn  ;
    }
   
    public void OnPointerDown(PointerEventData eventData)
    {
        entryDetailPanel.DownloadImage(movieTitle.text);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        entryDetailPanel.AnimateOut();         
    }
}
