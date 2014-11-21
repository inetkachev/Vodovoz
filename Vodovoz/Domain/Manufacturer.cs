﻿using System;
using QSOrmProject;

namespace Vodovoz
{
	[OrmSubjectAttributes("Производители")]
	public class Manufacturer : IDomainObject
	{
		#region Свойства
		public virtual int Id { get; set; }
		public virtual string Name { get; set; }
		#endregion

		public Manufacturer()
		{
			Name = String.Empty;
		}
	}
}
