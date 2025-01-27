public class Warrior
{
    private static readonly string[] Ranks = {
        "Pushover", "Novice", "Fighter", "Warrior", "Veteran",
        "Sage", "Elite", "Conqueror", "Champion", "Master", "Greatest"
    };
    public int Level { get; private set; } = 1;
    public int Experience { get; private set; } = 100;
    public string Rank => Ranks[Level / 10];
    public List<string> Achievements { get; } = new List<string>();

    public void GainExperience(int amount)
    {
        int newExperience = Math.Min(10000, Experience + amount);
        Experience = newExperience;
        Level = (Experience - 100) / 100 + 1;  // Correction du calcul du niveau
    }

    public string Battle(int enemyLevel)
    {
        if (enemyLevel < 1 || enemyLevel > 100) return "Invalid level";
        int levelDiff = enemyLevel - Level;

        // Vérification de la défaite dès que l'ennemi est largement plus fort
        if (levelDiff >= 5)
        {
            return "You've been defeated";
        }

        int xpGained;
        string result;

        if (levelDiff <= -2)
        {
            xpGained = 0;
            result = "Easy fight";
        }
        else if (levelDiff <= 0)
        {
            xpGained = levelDiff == 0 ? 10 : 5;
            result = "A good fight";
        }
        else
        {
            xpGained = 20 * levelDiff * levelDiff;
            result = "An intense fight";
        }

        GainExperience(xpGained);
        return result;
    }

    public string Training(string[] training)
    {
        if (training.Length != 3) return "Not strong enough";

        string description = training[0];
        int xp = int.Parse(training[1]);
        int requiredLevel = int.Parse(training[2]);

        if (Level >= requiredLevel)
        {
            GainExperience(xp);
            Achievements.Add(description);
            return description;
        }
        return "Not strong enough";
    }
}