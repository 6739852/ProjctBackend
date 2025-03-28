namespace The_Project.Models
{
    public class ReturnSupplier
    {
        public string Token { get; set; }
        public string Name { get; set; }
        public int NumOfGroups { get; set; }
        public string Role { get; set; }

        public ReturnSupplier(string token, string name, int numOfGroups)
        {
            this.Token = token;
            this.Name = name;
            this.NumOfGroups = numOfGroups;
            this.Role = "Supplier";
        }
    }
}
