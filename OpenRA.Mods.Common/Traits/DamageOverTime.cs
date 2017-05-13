#region Copyright & License Information
/*
 * Copyright 2007-2017 The OpenRA Developers (see AUTHORS)
 * This file is part of OpenRA, which is free software. It is made
 * available to you under the terms of the GNU General Public License
 * as published by the Free Software Foundation, either version 3 of
 * the License, or (at your option) any later version. For more
 * information, see COPYING.
 */
#endregion

using OpenRA.Graphics;
using OpenRA.Mods.Common.Traits.Render;
using OpenRA.Traits;

namespace OpenRA.Mods.Common.Traits
{
	[Desc("This actor will take damage over time.")]
	class DamageOverTimeInfo : ITraitInfo
	{
		public readonly int Damage = 1;
		public readonly int Interval = 8;

		public object Create(ActorInitializer init) { return new DamageOverTime(init.Self, this); }
	}

	class DamageOverTime : ITick, ISync
	{
		readonly DamageOverTimeInfo info;
		[Sync] int ticks;

		public DamageOverTime(Actor self, DamageOverTimeInfo info)
		{
			this.info = info;
		}

		public void Tick(Actor self)
		{
			if (--ticks <= 0)
			{
				self.InflictDamage(self, new Damage(info.Damage));
				ticks = info.Interval;
			}
		}
	}
}
