﻿using System;
using QS.Project.Domain;

namespace Vodovoz.PermissionExtensions
{
	public interface IPermissionExtension
	{
		string PermissionId { get; }

		string Name { get; }

		string Description { get; }

		bool IsValidType(Type typeOfEntity);
	}
}
