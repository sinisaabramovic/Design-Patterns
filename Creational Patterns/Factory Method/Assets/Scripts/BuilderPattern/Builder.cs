using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour {

    // Use this for initialization
    LevelDirector levelDirector;
	void Start () 
    {
        levelDirector = new LevelDirector();

        LevelBuilder simpleIceLevelBuilder = new IceLevelBuilder();
        LevelBuilder complexFireLevelBuilder = new FireLevelBuilder();

        levelDirector.ConstructSimpleLevel(simpleIceLevelBuilder);
        levelDirector.ConstructComplexLevel(complexFireLevelBuilder);

        Level simpleIceLevel = simpleIceLevelBuilder.GetLevel();
        Level complexFireLevel = complexFireLevelBuilder.GetLevel();

        simpleIceLevel.PrintLevel();
        complexFireLevel.PrintLevel();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public class LevelDirector
{
    public void ConstructSimpleLevel(LevelBuilder builder)
    {
        builder.BuildFloor();
        builder.BuildNPC();
    }

    public void ConstructComplexLevel(LevelBuilder builder)
    {
        builder.BuildFloor();
        for (int i = 0; i < 10; i++)
        {
            builder.BuildNPC();
        }
    }
}

// Basicly interface
public abstract class LevelBuilder
{
    public abstract void BuildFloor();
    public abstract void BuildNPC();
    public abstract Level GetLevel();
}

public class IceLevelBuilder : LevelBuilder
{
    private Level _iceLevel = new Level();

    public override void BuildFloor()
    {
        _iceLevel.Floor = "Ice Floor";
    }

    public override void BuildNPC()
    {
        _iceLevel.AddNPC("Ice NPC");
    }

    public override Level GetLevel()
    {
        return _iceLevel;
    }
}

public class FireLevelBuilder : LevelBuilder
{
    private Level _fireLevel = new Level();

    public override void BuildFloor()
    {
        _fireLevel.Floor = "Fire Floor";
    }

    public override void BuildNPC()
    {
        _fireLevel.AddNPC("Fire NPC");
    }

    public override Level GetLevel()
    {
        return _fireLevel;
    }
}

public class Level
{
    private string _floor;
    private List<string> _npcs = new List<string>();

    public string Floor
    {
        get { return _floor; }
        set { _floor = value; }
    }

    public void AddNPC(string npc)
    {
        _npcs.Add(npc);
    }

    public void PrintLevel(){
        Debug.Log("Level contains te following: ");
        Debug.Log("Floor: " + Floor);
        foreach(string npc in _npcs)
        {
            Debug.Log("NPC: " + npc);
        }
    }
}
