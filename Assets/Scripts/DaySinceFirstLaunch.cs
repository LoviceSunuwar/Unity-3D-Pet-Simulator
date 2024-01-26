using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaySinceFirstLaunch : MonoBehaviour
{
    System.DateTime startDate;
    System.DateTime today;

    private void Awake()
    {
        SetStartDate();

    }

    void SetStartDate()
    {
        if (PlayerPrefs.HasKey("StartDate"))
        {
            startDate = System.Convert.ToDateTime(PlayerPrefs.GetString("StartDate"));
        }
        else
        {
            startDate = System.DateTime.Now;
            PlayerPrefs.SetString("StartDate", startDate.ToString());

        }
        PlayerPrefs.SetInt("DaysPlayed", GetDaysPlayed());
    }

    int GetDaysPlayed()
    {
        today = System.DateTime.Now;
        System.TimeSpan elapsed = today.Subtract(startDate); // The time that has paassed ebtween the start date and the todays date
        double days = elapsed.TotalDays;
        return int.Parse(days.ToString("0"));
    }
}
