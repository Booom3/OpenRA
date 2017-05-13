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
	[Desc("This actor will play a fire animation over its body.")]
	class BurnsVisualOnlyInfo : ITraitInfo, Requires<RenderSpritesInfo>
	{
		public readonly string Anim = "1";

		public object Create(ActorInitializer init) { return new BurnsVisualOnly(init.Self, this); }
	}

	class BurnsVisualOnly
	{
		readonly BurnsVisualOnlyInfo info;

		public BurnsVisualOnly(Actor self, BurnsVisualOnlyInfo info)
		{
			this.info = info;

			var anim = new Animation(self.World, "fire", () => 0);
			anim.IsDecoration = true;
			anim.PlayRepeating(info.Anim);
			self.Trait<RenderSprites>().Add(anim);
		}
	}
}
