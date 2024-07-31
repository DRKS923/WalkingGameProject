using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerManagerTests
{
    
    [Test]
    
    public void ExpToLevelTest()
    {
        PlayerManager playerManager = new PlayerManager();
        playerManager.playerLevel = 5;
        playerManager.targetExp = playerManager.TargetExpCalc(playerManager.playerLevel);

        Assert.AreEqual(110, playerManager.targetExp);

    }

}
