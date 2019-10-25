/* Copyright (c) 2019 Rick (rick 'at' gibbed 'dot' us)
 *
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 *
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would
 *    be appreciated but is not required.
 *
 * 2. Altered source versions must be plainly marked as such, and must not
 *    be misrepresented as being the original software.
 *
 * 3. This notice may not be removed or altered from any source
 *    distribution.
 */

using System;
using UnrealScriptFormats;

namespace Script.GbxInventory
{
    public class InventoryPartData : GbxGameSystemCore.ActorPartData, IStubbed
    {
        private GbxGameSystemCore.AttributeInitializationData _MonetaryValueModifier;
        private GbxGameSystemCore.AttributeInitializationData _InventoryScoreModifier;
        // TODO(gibbed): These are probably TaggedArrays.
        private ObjectReference<InventoryNamePartData>[] _PrefixPartList;
        private ObjectReference<InventoryNamePartData>[] _TitlePartList;
        private ObjectReference<InventoryNamePartData>[] _SuffixPartList;
        private Name _InventoryNamingTag;
        private GbxGameSystemCore.AttributeEffectData[] _InventoryAttributeEffects;
        private GbxGameSystemCore.InstigatorAttributeEffectData[] _InstigatorAttributeEffects;
        private GbxGameSystemCore.UIStatPriorityData[] _UIStats;
        private bool _IsAvailableForPartInspection;
        private ObjectReference<GbxGameSystemCore.UIStatData_Text>[] _PartInspectionTitleOverride;
        private ObjectReference<GbxGameSystemCore.UIStatData_Text> _PartInspectionDescription;
        private bool _HideStatsForPartInspection;
        private ObjectReference<InventoryAspectData>[] _AspectList;
        private string _GearBuilderDescription;
        private bool _ShouldIgnorePartBoundsForPickupAttachment;
        private Name[] _ExcludedGestaltMeshPartNamesForItemInspectionAndThumbnailBounds;
        private Guid _AssetGuid;
    }
}
