using Microsoft.Xna.Framework;

namespace FNAGame
{
	public class FNAGame : Game
	{
		private readonly GraphicsDeviceManager graphics;

		public FNAGame()
		{
			graphics = new GraphicsDeviceManager(this);
		}

		protected override void Draw(GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
		}
	}
}
