using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class WarriorTests
{
    [Test]
    public void Warrior_ShouldStartWithDefaultValues()
    {
        // Arrange & Act
        var warrior = new Warrior();

        // Assert
        Assert.AreEqual(1, warrior.Level);
        Assert.AreEqual(100, warrior.Experience);
        Assert.AreEqual("Pushover", warrior.Rank);
        CollectionAssert.IsEmpty(warrior.Achievements);
    }

    [Test]
    public void Warrior_ShouldIncreaseLevel_WhenExperienceExceedsThreshold()
    {
        // Arrange
        var warrior = new Warrior();

        // Act
        warrior.GainExperience(200);

        // Assert
        Assert.AreEqual(3, warrior.Level);
        Assert.AreEqual(300, warrior.Experience);
    }

    [Test]
    public void Warrior_ShouldUpdateRank_WhenLevelReachesThreshold()
    {
        // Arrange
        var warrior = new Warrior();

        // Act
        warrior.GainExperience(900); // Monte au niveau 10

        // Assert
        Assert.AreEqual(10, warrior.Level);
        Assert.AreEqual("Novice", warrior.Rank);
    }

    [Test]
    public void Battle_WhenSameLevel_ShouldReturnGoodFightAndGainExperience()
    {
        // Arrange
        var warrior = new Warrior();

        // Act
        var result = warrior.Battle(1); // Même niveau

        // Assert
        Assert.AreEqual("A good fight", result);
        Assert.AreEqual(110, warrior.Experience);
        Assert.AreEqual(1, warrior.Level);
    }

    [Test]
    public void Battle_WhenEnemyTooStrong_ShouldReturnDefeated()
    {
        // Arrange
        var warrior = new Warrior();

        // Act
        var result = warrior.Battle(8); 

        // Assert
        Assert.AreEqual("You've been defeated", result);
    }

    [Test]
    public void Battle_WhenEnemyHigherLevel_ShouldReturnIntenseFightAndGainExperience()
    {
        // Arrange
        var warrior = new Warrior();

        // Act
        var result = warrior.Battle(3); // Ennemi 2 niveaux plus haut

        // Assert
        Assert.AreEqual("An intense fight", result);
        Assert.AreEqual(180, warrior.Experience); // Gagne 20 * 2 * 2 = 80 XP
        Assert.AreEqual(1, warrior.Level);
    }

    [Test]
    public void Training_WhenLevelRequirementMet_ShouldIncreaseExperienceAndRecordAchievement()
    {
        // Arrange
        var warrior = new Warrior();
        var initialExperience = warrior.Experience;  // 100 par défaut

        // Act
        var result = warrior.Training(new string[] { "Special Training", "300", "1" });

        // Assert
        Assert.AreEqual("Special Training", result);
        Assert.AreEqual(initialExperience + 300, warrior.Experience);  // Total 400 XP
        Assert.AreEqual(5, warrior.Level); // 400 XP = niveau 5
        CollectionAssert.Contains(warrior.Achievements, "Special Training");
    }

    [Test]
    public void Training_WhenLevelRequirementNotMet_ShouldReturnNotStrongEnough()
    {
        // Arrange
        var warrior = new Warrior();

        // Act
        var result = warrior.Training(new string[] { "Elite Training", "500", "10" });

        // Assert
        Assert.AreEqual("Not strong enough", result);
        Assert.AreEqual(100, warrior.Experience); // Aucune augmentation
        CollectionAssert.IsEmpty(warrior.Achievements); // Pas d'enregistrement
    }
}
