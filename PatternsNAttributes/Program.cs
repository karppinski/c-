namespace PatternsNAttributes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool IsJanetOrJohn(string name) =>
                name.ToUpper() is var upper && (upper == "JANNET" || upper == "JOHN");

            string GetWeightCategory(decimal bmi) => bmi switch
            {
                < 18.5m => "underweight",
                < 25m => "normal",
                < 30m => "overwieght",
                _ => "obese"
            };

            bool IsVowel(char c) => c is 'a' or 'e' or 'i' or 'o' or 'u';

            bool Bettween1And9(int n) => n is >= 1 and <= 9;

            bool IsLetter(char c) => c is >= 'a' and <= 'z'
                                       or >= 'A' and <= 'Z';


            bool ShouldAllow(Uri uri) => uri switch
            {
                { Scheme: "http", Port: 80 } => true,
                { Scheme.Length : 4, Port: 80 } => true,
                { Host.Length : < 1000, Port: >0 } => true,

                { Scheme: "https", Port: 443 } => true,
                { Scheme: "ftp", Port: 21 } => true,
                { IsLoopback: true } => true,
                _ => false
            };



        }
    }
}
