namespace ticketing_system.Classes
{
    public class CodeGenerator
    {
        public int Code { get; set; }
        private static Random random = new Random();

        public void generate()
        {
            Code = random.Next(999999);
        }
    }
}
