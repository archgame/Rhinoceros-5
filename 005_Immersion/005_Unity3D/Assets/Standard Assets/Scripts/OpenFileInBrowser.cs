using UnityEngine;
using UnityEditor;
using System.Collections;

public class OpenFileInBrowser : MonoBehaviour {

	public string folderpath;
	string path;
	string extension;
	public GameObject musicAnalysis;
	string songName;
	float length;
	AudioSource song;

	void Start(){

		//ShowExplorer(folderpath);
		//Apply ();
		StartCoroutine(LoadSongCoroutine());

	}

	IEnumerator LoadSongCoroutine()
	{
		string url = string.Format("file://{0}", path); 
		WWW www = new WWW(url);
		yield return www;
		
		song.clip = www.GetAudioClip(false, false);
		songName =  song.clip.name;
		length = song.clip.length;
	}

	/*[MenuItem( "Example/Overwrite Texture" )]
	static void Apply( )
	{
		Texture2D texture = Selection.activeObject as Texture2D;
		if( texture == null )
		{
			EditorUtility.DisplayDialog( "Select Texture", "You must select a texture first!", "OK" );
			Debug.Log ("texture");
			return;

		}

		string path = EditorUtility.OpenFilePanel( "Overwrite with png", "", "png" );
		if( path.Length != 0 )
		{
			WWW www = new WWW( "file:///" + path );
			www.LoadImageIntoTexture( texture );
			Debug.Log ("image");
		}
	}
	

	/*public void ShowExplorer(string itemPath)
	{
		itemPath = itemPath.Replace(@"/", @"\");   // explorer doesn't like front slashes
		System.Diagnostics.Process.Start("explorer.exe", "/select,"+itemPath);
	}

	public static class OpenInFileBrowser
	{
		public static bool IsInMacOS
		{
			get
			{
				return UnityEngine.SystemInfo.operatingSystem.IndexOf("Mac OS") != -1;
			}
		}
		
		public static bool IsInWinOS
		{
			get
			{
				return UnityEngine.SystemInfo.operatingSystem.IndexOf("Windows") != -1;
			}
		}
		
		[UnityEditor.MenuItem("Window/Test OpenInFileBrowser")]
		public static void Test()
		{
			Open(UnityEngine.Application.dataPath);
		}
		
		public static void OpenInMac(string path)
		{
			bool openInsidesOfFolder = false;
			
			// try mac
			string macPath = path.Replace("\\", "/"); // mac finder doesn't like backward slashes
			
			if ( System.IO.Directory.Exists(macPath) ) // if path requested is a folder, automatically open insides of that folder
			{
				openInsidesOfFolder = true;
			}
			
			if ( !macPath.StartsWith("\"") )
			{
				macPath = "\"" + macPath;
			}
			
			if ( !macPath.EndsWith("\"") )
			{
				macPath = macPath + "\"";
			}
			
			string arguments = (openInsidesOfFolder ? "" : "-R ") + macPath;
			
			try
			{
				System.Diagnostics.Process.Start("open", arguments);
			}
			catch ( System.ComponentModel.Win32Exception e )
			{
				// tried to open mac finder in windows
				// just silently skip error
				// we currently have no platform define for the current OS we are in, so we resort to this
				e.HelpLink = ""; // do anything with this variable to silence warning about not using it
			}
		}
		
		public static void OpenInWin(string path)
		{
			bool openInsidesOfFolder = false;
			
			// try windows
			string winPath = path.Replace("/", "\\"); // windows explorer doesn't like forward slashes
			
			if ( System.IO.Directory.Exists(winPath) ) // if path requested is a folder, automatically open insides of that folder
			{
				openInsidesOfFolder = true;
			}
			
			try
			{
				System.Diagnostics.Process.Start("explorer.exe", (openInsidesOfFolder ? "/root," : "/select,") + winPath);
			}
			catch ( System.ComponentModel.Win32Exception e )
			{
				// tried to open win explorer in mac
				// just silently skip error
				// we currently have no platform define for the current OS we are in, so we resort to this
				e.HelpLink = ""; // do anything with this variable to silence warning about not using it
			}
		}
		
		public static void Open(string path)
		{
			if ( IsInWinOS )
			{
				OpenInWin(path);
			}
			else if ( IsInMacOS )
			{
				OpenInMac(path);
			}
			else // couldn't determine OS
			{
				OpenInWin(path);
				OpenInMac(path);
			}
		}
	}*/
}
