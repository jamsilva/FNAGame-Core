using System;
using System.IO;
using System.Runtime.InteropServices;

namespace FNAGame
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			// https://github.com/FNA-XNA/FNA/wiki/7:-FNA-Environment-Variables#fna_graphics_enable_highdpi
			// NOTE: from documentation:
			//       Lastly, when packaging for macOS, be sure this is in your app bundle's Info.plist:
			//           <key>NSHighResolutionCapable</key>
			//           <string>True</string>
			Environment.SetEnvironmentVariable("FNA_GRAPHICS_ENABLE_HIGHDPI", "1");

			using var game = new FNAGame();
			game.Run();
		}
	}
}