using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntryView : MonoBehaviour
{
    public Text movieTitle;
    public Text titleYear;
    public Text duration;
    public Text Genres;
    public Text CastInfo;
        
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
    
}
