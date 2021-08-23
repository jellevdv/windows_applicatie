namespace WindowsApplicatie_NetteVersie.Models
{
    public class CustomError
    {
        public string Scope { get; set; }
        public string Message { get; set; }

        public CustomError() { }

        public CustomError(string s, string m)
        {
            Scope = s;
            Message = m;
        }
    }
}
