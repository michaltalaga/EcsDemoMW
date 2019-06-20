using System;
using System.Collections.Generic;

namespace NonEcsModel
{
	public abstract class BaseObject
	{
		public List<Object> Components { get; set; }
		public int Id { get; set; }
	}
}
