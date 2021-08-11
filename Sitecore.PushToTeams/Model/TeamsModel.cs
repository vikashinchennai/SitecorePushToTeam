using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sitecore.PushToTeams.Model
{
    public class Fact
    {
        public Fact() { }
        public Fact(string name, string value) { this.name = name; this.value = value; }
        public string name { get; set; }
        public string value { get; set; }
    }

    public class Section
    {
        public Section()
        {
            facts = new List<Fact>();
        }
        public string activityTitle { get; set; }
        public string activitySubtitle { get; set; }
        public List<Fact> facts { get; set; }
        public bool markdown { get { return true; } }
    }

    public class TeamsModel
    {
        public TeamsModel()
        {
            sections = new List<Section>();
        }
        [JsonProperty("@type")]
        public string Type { get { return "MessageCard"; } }

        [JsonProperty("@context")]
        public string Context { get { return "http://schema.org/extensions"; } }
        public string themeColor { get { return "0076D7"; } }
        public string summary { get; set; }
        public List<Section> sections { get; set; }
    }


}