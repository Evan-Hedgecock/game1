using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TextureAtlas
{
    public class AnimatedSprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;

        public AnimatedSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            totalFrames = rows * columns;
        }
		
		public void Update()
		{
			currentFrame++;
			if (currentFrame == totalFrames)
			{
				currentFrame = 0;
			}
		}

		public void Draw(SpriteBatch spriteBatch, Vector2 location)
		{
			int width = Texture.Width / Columns;
			int height = Texture.Height / Rows;
			int row = currentFrame / Columns;
			int column = currentFrame % Columns;
			
			Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
			Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);
			spriteBatch.Begin();
			spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
			spriteBatch.End();
		}
	}
}

