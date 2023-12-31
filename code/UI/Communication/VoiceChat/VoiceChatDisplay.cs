using Sandbox;
using Sandbox.UI;
using System.Linq;

namespace TTT.UI;

public partial class VoiceChatDisplay : Panel
{
	public static VoiceChatDisplay Instance { get; private set; }

	public VoiceChatDisplay() => Instance = this;

	public void OnVoicePlayed( IClient client )
	{
		var entry = ChildrenOfType<VoiceChatEntry>().FirstOrDefault( x => x.Friend.Id == client.SteamId ) ?? new VoiceChatEntry( client ) { Parent = this };
		entry.Update( client.Voice.CurrentLevel );
	}

	public override void Tick()
	{
		if ( Voice.IsRecording )
			OnVoicePlayed( Game.LocalClient );
	}
}
