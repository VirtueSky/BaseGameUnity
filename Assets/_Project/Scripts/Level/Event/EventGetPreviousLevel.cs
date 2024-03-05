using UnityEngine;
using VirtueSky.Events;
using VirtueSky.Inspector;

[CreateAssetMenu(menuName = "Event Custom/Event Get Previous Level", fileName = "event_get_previous_level")]
[EditorIcon("scriptable_event")]
public class EventGetPreviousLevel : EventNoParamResult<Level>
{
}