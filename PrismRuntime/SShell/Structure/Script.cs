﻿namespace PrismRuntime.SShell.Structure
{
	/// <summary>
	/// This is the base class all commands must inherit.
	/// </summary>
	public abstract class Script
	{
		public Script(string ScriptName, string BasicDescription)
		{
			AdvancedDescription = string.Empty;
			this.BasicDescription = BasicDescription;
			this.ScriptName = ScriptName;

			Shell.Scripts.Add(this);
		}

		#region Methods

		public abstract void Invoke(string[] Args);

		#endregion

		#region Fields

		public string AdvancedDescription { get; set; }
		public string BasicDescription { get; set; }
		public string ScriptName { get; set; }

		#endregion
	}
}