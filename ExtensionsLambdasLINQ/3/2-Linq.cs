using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionsLambdasLINQ.Linq
{
    public class User
    {
        public string FullName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Location { get; set; }
    }

    public class Processor
    {
        public void Process(List<User> users)
        {
            DateTime ago18Years = DateTime.Now.AddYears(-18);
            var queryOver18 = users.Where(u => u.Birthdate > ago18Years);
            var locations = queryOver18
                .Select(u =>
                {
                    var nameParts = u.FullName.Split(' ');
                    return new
                    {
                        FirstName = nameParts[0],
                        LastName = string.Join(' ', nameParts.Skip(1)),
                        u.Location,
                    };
                })
                .GroupBy(u => u.Location)
                .Select(gr => new
                {
                    Location = gr.Key,
                    Users = gr.OrderBy(ud => ud.FirstName).ToList(),
                });

            var maxLocationSize = locations.Max(gd => gd.Users.Count); // Use Count property instead of Count() LINQ method

            var locDict = locations.ToDictionary(l => l.Location, l => l.Users);
            var usersOfDenver = locDict["Denver"];

            var hasDanny = queryOver18.Any(u => u.FullName.StartsWith("Danny "));

            // if no such locations - fail
            var bigLocation1 = locations.First(l => l.Users.Count > 300);

            // if no such locations - return null
            var bigLocation2 = locations.FirstOrDefault(l => l.Users.Count > 300);

            // if there are more than 1 such locations - fail
            var bigLocation3 = locations.Single(l => l.Users.Count > 300);


            var allGroups = users
                .Select(u => u.Location)
                .Distinct()
                .ToList();
        }
    }
}
