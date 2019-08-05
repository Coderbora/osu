﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using Foundation;
using osu.Framework.Platform;
using osu.Game;

namespace osu.iOS
{
    public class OsuGameIOS : OsuGame
    {
        public override Storage GetStorageForStableInstall() => Storage;
        public override Version AssemblyVersion => new Version(NSBundle.MainBundle.InfoDictionary["CFBundleVersion"].ToString());
    }
}
