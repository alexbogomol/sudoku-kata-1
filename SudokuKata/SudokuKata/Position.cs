namespace SudokuKata
{
	public class Position
	{
		private Position(int index)
		{
			Index = index;
			Row = index / 9;
			Column = index % 9;
		}

		public int Discriminator { get; private set; }
		public string Description { get; private set; }
		public int Index { get; }
		public int Row { get; }
		public int Column { get; }

		public static Position ByColumn(int index)
		{
			return new Position(index)
			{
				Discriminator = 9 + index % 9,
				Description = $"column #{index % 9 + 1}"
			};
		}

		public static Position ByRow(int index)
		{
			return new Position(index)
			{
				Discriminator = index / 9,
				Description = $"row #{index / 9 + 1}"
			};
		}

		public static Position ByBlock(int index)
		{
			var position = new Position(index);

			position.Discriminator = 18 + 3 * (position.Row / 3) + position.Column / 3;
			position.Description = $"block ({position.Row / 3 + 1}, {position.Column / 3 + 1})";

			return position;
		}
	}
}