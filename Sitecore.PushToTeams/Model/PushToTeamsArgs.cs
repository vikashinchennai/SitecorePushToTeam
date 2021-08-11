
namespace Sitecore.PushToTeams.Model
{
    using Sitecore.Pipelines;
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [Serializable]
    public class PushToTeamsArgs : PipelineArgs
    {
        public Dictionary<string, string> Facets { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Summary { get; set; }

        public PushToTeamsArgs() { }

        protected PushToTeamsArgs(SerializationInfo info, StreamingContext context) : base(info, context) { }

    }
}