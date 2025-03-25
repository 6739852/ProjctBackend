namespace The_Project.Models
{
    public class ReturnUser
    {
        public string Token { get; set; }
        public string Name { get; set; }
        public int NumOfCurrentGroups { get; set; }
        public int NumOfWaitingGroups { get; set; }
        public ReturnUser(string token, string name, int numOfCurrentGroups,int numOfWaitingGroups)
        {
            this.Token = token;
            this.Name = name;
            this.NumOfCurrentGroups = numOfCurrentGroups;
            this.NumOfWaitingGroups = numOfWaitingGroups;
        }
    }
}
