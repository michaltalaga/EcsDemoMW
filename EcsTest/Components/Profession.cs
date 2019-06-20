using System;
using System.Collections.Generic;
using System.Text;

namespace EcsTest.Components
{
	public class Profession : IComponent
	{
		public Profession(Role role)
		{
			Role = role;
		}
		public Role Role { get; set; }
	}
	public enum Role
	{
		Warrior,
		Mage,
		Priest,
	}
}
