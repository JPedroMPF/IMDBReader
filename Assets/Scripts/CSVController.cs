using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

public class CSVController : MonoBehaviour
{
    public static Dictionary<int, Movie> moviesDict = new Dictionary<int, Movie>();

    public delegate void MoviesDictReady();
    public static event MoviesDictReady onMoviesDictReady;

    void Start()
    {
        LoadCSV();
    }   

    private void LoadCSV()
    {
        TextAsset questdata = Resources.Load<TextAsset>("movie_metadata");

        string[] row = questdata.text.Split(new char[] { '\n' });

        for (int r = 1; r < row.Length - 1; r++)
        {
            string[] collum = row[r].Split(new char[] { ',' });

            Movie movieEntry = new Movie();
            movieEntry.directorName = collum[1];
            movieEntry.numCritForReviews = collum[2];
            movieEntry.duration = collum[3];
            movieEntry.directorFacebookLikes = collum[4];
            movieEntry.actor3FacebookLikes = collum[5];
            movieEntry.actor2Name = collum[6];
            movieEntry.actor1FacebookLikes = collum[7];
            movieEntry.gross = collum[8];
            movieEntry.genres = collum[9];
            movieEntry.actor1Name = collum[10];
            movieEntry.movieTitle = collum[11];
            movieEntry.numVotedUsers = collum[12];
            movieEntry.castTotalFacebookLikes = collum[13];
            movieEntry.actor3Name = collum[14];
            movieEntry.facenumberInPoster = collum[15];
            movieEntry.plotKeywords = collum[16];
            movieEntry.movieImdbLink = collum[17];
            movieEntry.numUserForReviews = collum[18];
            movieEntry.language = collum[19];
            movieEntry.country = collum[20];
            movieEntry.contentRating = collum[21];
            movieEntry.budget = collum[22];
            movieEntry.titleYear = collum[23];
            movieEntry.actor2FacebookLikes = collum[24];
            movieEntry.imdbScore = collum[25];
            movieEntry.aspectRatio = collum[26];
            movieEntry.movieFacebookLikes = collum[27];

            moviesDict.Add(r, movieEntry);

            
        }

        onMoviesDictReady?.Invoke();
    }   

    public static Dictionary<int,Movie> GetMoviesDict()
    {
        if (moviesDict == null)
            return null;

        return moviesDict;
    }

    
}