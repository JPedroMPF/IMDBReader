using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntriesController : MonoBehaviour
{
    public GameObject entryViewPrefab;
    public EntryDetailPanel detailsEntryPanel;
    public GameObject listContent;
    public ScrollViewEvents scrollViewEvents;

    int maxEntriesBuffer = 80;
    int initialEntriesToLoad = 40;

    float prefabHeight;   

    List<GameObject> entriesList = new List<GameObject>();


    private void OnEnable()
    {
        CSVController.onMoviesDictReady += AddInitialEntries;
        ScrollViewEvents.onScrolling += UpdateEntries;
    }

    private void OnDisable()
    {
        CSVController.onMoviesDictReady -= AddInitialEntries;
        ScrollViewEvents.onScrolling -= UpdateEntries;
    }

    private void Start()
    {
        prefabHeight = entryViewPrefab.GetComponent<RectTransform>().rect.height;
    }

    private void UpdateEntries(float scrollAmount, ScrollDirection direction)
    {

        int entriesToUpdate = (int)Mathf.Ceil( scrollAmount / prefabHeight) ;

        if(direction == ScrollDirection.Down)
        {   
            AddBottom(entriesToUpdate);     
            
            if(entriesList.Count > maxEntriesBuffer)
            {
                RemoveTop(entriesToUpdate);
                scrollViewEvents.UpdatePosition((prefabHeight * entriesToUpdate),ScrollDirection.Down);
            }
        }
        else
        {
            AddTop(entriesToUpdate);

            if (entriesList.Count > maxEntriesBuffer)
            {
                RemoveBot(entriesToUpdate);
                scrollViewEvents.UpdatePosition((prefabHeight * entriesToUpdate), ScrollDirection.Up);
            }           
        }
    }

    private void AddBottom(int entriesToUpdate)
    {
        var currentLastEntry = int.Parse(entriesList[entriesList.Count - 1].transform.name);

        for (int i = currentLastEntry +1; i < currentLastEntry + entriesToUpdate; i++)
        {
            GameObject entry = Instantiate(entryViewPrefab, listContent.transform);
            entry.transform.name = i.ToString();

            SetEntryValues(entry, i);

            entriesList.Add(entry);

        }
    }

    private void AddTop(int entriesToUpdate)
    {
        var currentFirstElement = int.Parse(entriesList[0].transform.name);

        for (int i = currentFirstElement - 1; i >= currentFirstElement - entriesToUpdate; i--)
        {
            if (i < 1)
                break;

            GameObject entry = Instantiate(entryViewPrefab, listContent.transform);
            entry.transform.name = i.ToString();
            entry.transform.SetSiblingIndex(0);

            SetEntryValues(entry, i);            

            entriesList.Insert(0, entry);

        }
    }

    

    private void RemoveTop(int entriesToUpdate)
    {
        

        for (int t = 0; t < entriesToUpdate; t++)
        {
            Destroy(entriesList[0]);
            entriesList.RemoveAt(0);
        }
    }

    private void RemoveBot(int entriesToUpdate)
    {
        for (int t = 0; t < entriesToUpdate; t++)
        {
            Destroy(entriesList[entriesList.Count - 1]);
            entriesList.RemoveAt(entriesList.Count - 1);
        }
    }

    void AddInitialEntries()
    {
        for (int i = 1; i <= initialEntriesToLoad; i++)
        {
            GameObject entry = Instantiate(entryViewPrefab, listContent.transform);
            entry.transform.name  = i.ToString();

            SetEntryValues(entry, i);

            entriesList.Add(entry);
        }
    }


    private void SetEntryValues(GameObject entry, int i)
    {
        EntryView entryView = entry.GetComponent<EntryView>();
        entryView.SetDetailsPanel(detailsEntryPanel);
        entryView.SetCastInfo(CSVController.moviesDict[i].directorName, CSVController.moviesDict[i].actor1Name, CSVController.moviesDict[i].actor2Name);
        entryView.SetDuration(CSVController.moviesDict[i].duration);
        entryView.SetGenres(CSVController.moviesDict[i].genres);
        entryView.SetMovieTitle(CSVController.moviesDict[i].movieTitle);
        entryView.SetTitleYear(CSVController.moviesDict[i].titleYear);
    }
}
