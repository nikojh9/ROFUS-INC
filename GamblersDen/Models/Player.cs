namespace GamblersDen.Models
{
    public class Player
    {

        public string UserName { get; set; }
        public string Password { get; set; }
        public int Dollars { get; set; } = 500;
        public int InvestmentReturns { get; set; } = 0;

        //public List<Investments> boughtInvestments { get; set; }

        //public List<Games> boughtGames { get; set; }


        public Player(string username, string password) {
            UserName = username;
            Password = password;
        }

    }
}
