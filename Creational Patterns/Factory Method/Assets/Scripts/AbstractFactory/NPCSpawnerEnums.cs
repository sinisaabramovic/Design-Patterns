using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbstractFactoryNamespace;

public enum EnemyTypes
{
    flying = 0,
    walking,
    swimming
};

public enum FriendlyTypes
{
    flying = 0,
    walking
};

public enum FactoryTypes
{
    enemy = 0,
    friendly
}