using System;

namespace Task
{
    class Company
    {
        public string Name;
        public int AvarageSalary;
        public string WebsiteDomain;
        private string ID;

        public Company()
        {
            Name = "PriorBank";
            AvarageSalary = 1000;
            WebsiteDomain = "by";
            ID = GenerationID();
        }

        public Company(string name = "", int avaragesalary = 0, string websitedomain = "")
        {
            Name = name;
            AvarageSalary = avaragesalary;
            WebsiteDomain = websitedomain;
            ID = GenerationID();
        }

        private static string GenerationID() => Guid.NewGuid().ToString();

        public override string ToString() => $"Name: {Name}\nAvarage salary: {AvarageSalary}\nWebsite domain: {WebsiteDomain}\nID: {ID}";
        
    }
}