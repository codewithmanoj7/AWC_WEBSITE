namespace AWC.Infra.Results
{
    public class UserCommandResult
    {
        public static (string alertType, string message) GetMessage(int resultCode)
        {
            return resultCode switch
            {
                1 => ("success", "The user details have been successfully processed."),
                -3 => ("warning", "A user with the same IC number or email already exists. Please use unique values and try again."),
                _ => ("error", "An unexpected status code was returned. Please try again.")
            };
        }
    }
}