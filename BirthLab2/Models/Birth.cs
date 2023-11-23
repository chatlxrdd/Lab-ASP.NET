using System;
namespace BirthLab2.Models
{
	public class Birth
	{
		public string? Name { get; set; }

		public DateTime BirthDate { get; set; }

		public bool isValid()
		{
			return !string.IsNullOrEmpty(Name) && BirthDate < DateTime.Now; 
		}

        public int CalculateAge()
        {
            TimeSpan ageDifference = DateTime.Now - BirthDate;
            int age = (int)(ageDifference.TotalDays / 365);
            return age;
        }
    }
}

