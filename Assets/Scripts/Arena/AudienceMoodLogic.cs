namespace SwordsAndSandals.Arena
{
    public class AudienceMoodLogic
    {
        private AudienceMoodData _audienceMoodData;

        public AudienceMoodLogic(PlayerController playerController, PlayerController aiController, AudienceMoodData audienceMoodData)
        { 
            _audienceMoodData = audienceMoodData;

            playerController.OnStartAction += StartAction;
            aiController.OnStartAction += StartAction;
        }

        private void StartAction(Enums.CurrentState state)
        {
            if (state == Enums.CurrentState.Dance)
            {
                _audienceMoodData.Current += 10;
            }
            else if (state == Enums.CurrentState.Sleep)
            {
                _audienceMoodData.Current -= 5;
            }
            else
            {
                _audienceMoodData.Current -= 2;
            }
        }
    }
}
