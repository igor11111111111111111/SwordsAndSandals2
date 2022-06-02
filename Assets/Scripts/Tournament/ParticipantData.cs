using CustomJson;

namespace SwordsAndSandals.Tournament
{
    public class ParticipantData
    {
        public bool IsAlive;
        public bool IsBoss;
        public PlayerData PlayerData;

        public ParticipantData(bool isBoss, string name, SerializedColor skinColor, PlayerDataExperience dataLevel, PlayerDataSkills dataSkills, Reward reward, PlayerDataArmors dataArmors, PlayerDataWeapons dataWeapons)
        {
            PlayerData = new PlayerData(name, skinColor, dataLevel, dataSkills, reward, dataArmors, dataWeapons);
            IsBoss = isBoss;

            IsAlive = true;
        }
    } 
}
