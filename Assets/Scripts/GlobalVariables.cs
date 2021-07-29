using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{

    public static int kills, deaths, dmgTakenText, dmgDealtText, peopleText, peopleTotal, totalKills, totalDeaths, totaldmgTakenText, totaldmgDealtText, totalpeopleText, totalpeopleTotal;

    public static string PreviousLevel;


    public int Kills { get => kills; set => kills = value; }
    public int Deaths { get => deaths; set => deaths = value; }
    public int DmgTakenText { get => dmgTakenText; set => dmgTakenText = value; }
    public int DmgDealtText { get => dmgDealtText; set => dmgDealtText = value; }
    public int PeopleText { get => peopleText; set => peopleText = value; }
    public int PeopleTotal { get => peopleTotal; set => peopleTotal = value; }
    public int TotalKills { get => totalKills; set => totalKills = value; }
    public int TotalDeaths { get => totalDeaths; set => totalDeaths = value; }
    public int TotaldmgTakenText { get => totaldmgTakenText; set => totaldmgTakenText = value; }
    public int TotaldmgDealtText { get => totaldmgDealtText; set => totaldmgDealtText = value; }
    public int TotalpeopleText { get => totalpeopleText; set => totalpeopleText = value; }
    public int TotalpeopleTotal { get => totalpeopleTotal; set => totalpeopleTotal = value; }
    public string PreviousLevel1 { get => PreviousLevel; set => PreviousLevel = value; }
}

