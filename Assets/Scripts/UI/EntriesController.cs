using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntriesController : MonoBehaviour
{
    public GameObject entryViewPrefab;
    public GameObject listContent;
    public ScrollViewEvents scrollViewEvents;
    public int entriesToLoad = 10;

    public int currentEntryNumbers = 1;
    

    private void OnEnable()
    {
        CSVController.onMoviesDictReady += PopulateView;
        ScrollViewEvents.onScrollEnd += PopulateView;
    }

    private void OnDisable()
    {
        CSVController.onMoviesDictReady -= PopulateView;
        ScrollViewEvents.onScrollEnd -= PopulateView;
    }


    void PopulateView()
    {
        scrollViewEvents.trackScroll = false;

        for (int i = currentEntryNumbers; i < currentEntryNumbers + entriesToLoad; i++)
        {
            GameObject entry = Instantiate(entryViewPrefab, listContent.transform);
            entry.name = CSVController.moviesDict[i].ToString();

            EntryView entryView = entry.GetComponent<EntryView>();
            entryView.SetCastInfo(CSVController.moviesDict[i].directorName, CSVController.moviesDict[i].actor1Name, CSVController.moviesDict[i].actor2Name);
            entryView.SetDuration(CSVController.moviesDict[i].duration);
            entryView.SetGenres(CSVController.moviesDict[i].genres);
            entryView.SetMovieTitle(CSVController.moviesDict[i].movieTitle);
            entryView.SetTitleYear(CSVController.moviesDict[i].titleYear);

        }
        currentEntryNumbers = currentEntryNumbers + entriesToLoad - 1;

        if(currentEntryNumbers < CSVController.moviesDict.Count)
            scrollViewEvents.trackScroll = true;
    }

}
