// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using MessagePack;
using osu.Game.Online.API;
using osu.Game.Online.Rooms;

namespace osu.Game.Online.Multiplayer
{
    [Serializable]
    [MessagePackObject]
    public class MultiplayerRoomSettings : IEquatable<MultiplayerRoomSettings>
    {
        [Key(0)]
        public int BeatmapID { get; set; }

        [Key(1)]
        public int RulesetID { get; set; }

        [Key(2)]
        public string BeatmapChecksum { get; set; } = string.Empty;

        [Key(3)]
        public string Name { get; set; } = "Unnamed room";

        [Key(4)]
        public IEnumerable<APIMod> RequiredMods { get; set; } = Enumerable.Empty<APIMod>();

        [Key(5)]
        public IEnumerable<APIMod> AllowedMods { get; set; } = Enumerable.Empty<APIMod>();

        [Key(6)]
        public long PlaylistItemId { get; set; }

        [Key(7)]
        public string Password { get; set; } = string.Empty;

        [Key(8)]
        public MatchType MatchType { get; set; }

        public bool Equals(MultiplayerRoomSettings other)
            => BeatmapID == other.BeatmapID
               && BeatmapChecksum == other.BeatmapChecksum
               && RequiredMods.SequenceEqual(other.RequiredMods)
               && AllowedMods.SequenceEqual(other.AllowedMods)
               && RulesetID == other.RulesetID
               && Password.Equals(other.Password, StringComparison.Ordinal)
               && Name.Equals(other.Name, StringComparison.Ordinal)
               && PlaylistItemId == other.PlaylistItemId
               && MatchType == other.MatchType;

        public override string ToString() => $"Name:{Name}"
                                             + $" Beatmap:{BeatmapID} ({BeatmapChecksum})"
                                             + $" RequiredMods:{string.Join(',', RequiredMods)}"
                                             + $" AllowedMods:{string.Join(',', AllowedMods)}"
                                             + $" Password:{(string.IsNullOrEmpty(Password) ? "no" : "yes")}"
                                             + $" Ruleset:{RulesetID}"
                                             + $" Type:{MatchType}"
                                             + $" Item:{PlaylistItemId}";
    }
}
