using System;

namespace Task
{
	class Company
	{
		public string Name { get; set; }
		public int AvarageSalary { get; set; }
		public string WebsiteDomain { get; set; }
		protected string ID { get; set; }

		public Company()
		{
			Name = "Priorbank";
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

		protected static string GenerationID() => Guid.NewGuid().ToString();

		public override string ToString() => $"Name: {Name}\nAvarage salary: {AvarageSalary}\nWebsite domain: {WebsiteDomain}\nID: {ID}";
	}
}