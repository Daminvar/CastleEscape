using System;
using System.IO;
using SFML;
using SFML.Graphics;
using SFML.Window;

namespace CastleEscape
{
	public class ContentManager
	{
		static string contentDir;
		
		public static void SetContentDir(string dir)
		{
			contentDir = dir;
		}
		
		public static Image LoadImage(string resourceName)
		{
			return new Image(string.Format("{0}{1}{2}.png", contentDir, Path.DirectorySeparatorChar, resourceName));
		}
	}
}
