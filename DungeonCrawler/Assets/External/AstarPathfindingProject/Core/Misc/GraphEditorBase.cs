using Pathfinding.Serialization;

namespace Pathfinding
{
    [JsonOptIn]
    public class GraphEditorBase
    {
        /// <summary>NavGraph this editor is exposing</summary>
        public NavGraph target;
    }
}