﻿using AssetRipper.Assets;
using AssetRipper.Assets.Metadata;
using AssetRipper.SourceGenerated.Classes.ClassID_1;
using AssetRipper.SourceGenerated.Classes.ClassID_111;
using AssetRipper.SourceGenerated.Classes.ClassID_74;
using AssetRipper.SourceGenerated.Classes.ClassID_95;

namespace AssetRipper.SourceGenerated.Extensions
{
	public static class AnimationClipExtensions
	{

		public enum AnimationType
		{
			Legacy = 1,
			Mecanim = 2,
			Human = 3,
		}

		public static bool GetLegacy(this IAnimationClip clip)
		{
			if (clip.Has_Legacy_C74())
			{
				return clip.Legacy_C74;
			}
			return clip.AnimationType_C74 == (int)AnimationType.Legacy;
		}

		public static IEnumerable<IGameObject> FindRoots(this IAnimationClip clip)
		{
			foreach (IUnityObjectBase asset in clip.Collection.Bundle.FetchAssetsInHierarchy())
			{
				if (asset is IAnimator animator)
				{
					if (animator.ContainsAnimationClip(clip))
					{
						yield return animator.GameObject_C8.GetAsset(animator.Collection);
					}
				}
				else if (asset is IAnimation animation)
				{
					if (animation.ContainsAnimationClip(clip))
					{
						yield return animation.GameObject_C8.GetAsset(animation.Collection);
					}
				}
			}

			yield break;
		}
	}
}
