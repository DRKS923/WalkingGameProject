using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class UnitTesting
{
    public void SetUp()
    {

    }
    [Test]
    public void StepIncrease()
    {
        /*StepCounter.Instance.prevStepCounter = 0;
        StepCounter.Instance.Steps = 0;


        StepCounter.Instance.TakeStep();
        Assert.AreEqual(1, StepCounter.Instance.Steps);
        Assert.AreEqual(StepCounter.Instance.Steps, StepCounter.Instance.prevStepCounter);*/
        
    }
    [Test]
    public void ExpToLevelTest()
    {
        PlayerManager.Instance.playerLevel = 5;
        PlayerManager.Instance.targetExp = PlayerManager.Instance.TargetExpCalc(PlayerManager.Instance.playerLevel);

        Assert.AreEqual(110, PlayerManager.Instance.targetExp);

    }

}
