﻿using System;

namespace Vertica.Utilities.Eventing
{
	public class ChainedEventArgs : EventArgs, IChainedEventArgs
	{
		/// <summary>
		/// The event sink sets this property to true if it handles the event.
		/// </summary>
		public bool Handled { get; set; }
	}
}