namespace Agendamentos.Global
{
    public class Security
    {
        public bool ValidateToken(string token)
        {
            bool result = true;

            if (string.IsNullOrEmpty(token))
            {
                result = false;


            }
            else if (token != Config.automaticPermanentToken)
            {
                result = false;
            }

            return result;
        }

        public string GenerateToken(string user, string pass)
        {
            string result = string.Empty;
           
            if (user == "admin" && pass == "admin")
            {
                Guid guid = Guid.NewGuid();
                result = guid.ToString();
                Config.automaticPermanentToken = result;
                
            }
            return result;
        }
    }
}
