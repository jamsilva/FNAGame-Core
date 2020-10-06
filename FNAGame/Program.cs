using System;
using System.IO;
using System.Runtime.InteropServices;

namespace FNAGame
{
	internal class Program
	{
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool SetDllDirectory(string lpPathName);

		private static void Main(string[] args)
		{
			// https://github.com/FNA-XNA/FNA/wiki/4:-FNA-and-Windows-API#64-bit-support
			if (Environment.OSVersion.Platform == PlatformID.Win32NT)
			{
				SetDllDirectory(Path.Combine(
					AppDomain.CurrentDomain.BaseDirectory,
					Environment.Is64BitProcess ? "x64" : "x86"
				));
			}

			// When not using MonoKickstart, we need to put the libraries in the same folder as the executable and do some trickery...
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
			{
				string libLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Environment.Is64BitProcess ? "lib64" : "lib");

				foreach (string filePath in Directory.GetFiles(libLocation))
				{
					string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path.GetFileName(filePath));
					File.Copy(filePath, destPath, true);
					int extIndex = destPath.LastIndexOf(".so");

					if (extIndex == -1)
						continue;

					File.Copy(filePath, destPath.Substring(0, extIndex), true);
				}
			}

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