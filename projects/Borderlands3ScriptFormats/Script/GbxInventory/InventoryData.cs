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
    public class InventoryData : GbxRuntime.GbxDataAsset, IStubbed
    {
        #region Properties
        private bool _InventoryNameIsFullName;
        private Text _InventoryName;
        // TODO(gibbed): these are probably TaggedArrays.
        private ObjectReference<InventoryNamePartData>[] _PrefixPartList;
        private ObjectReference<InventoryNamePartData>[] _TitlePartList;
        private ObjectReference<InventoryNamePartData>[] _SuffixPartList;
        private ObjectReference<InventoryNamingStrategyData> _NamingStrategy;
        private ObjectReference _InventoryActorClass;
        private Guid _AssetGuid;
        #endregion

        #region Properties
        public bool InventoryNameIsFullName
        {
            get => this._InventoryNameIsFullName;
            set => this._InventoryNameIsFullName = value;
        }

        public Text InventoryName
        {
            get => this._InventoryName;
            set => this._InventoryName = value;
        }

        public ObjectReference InventoryActorClass
        {
            get => this._InventoryActorClass;
            set => this._InventoryActorClass = value;
        }

        public Guid AssetGuid
        {
            get => this._AssetGuid;
            set => this._AssetGuid = value;
        }
        #endregion
        protected override bool SerializeProperty(IUnrealSerializer serializer, ref PropertyTag tag)
        {
            if (tag.Name == "bInventoryNameIsFullName")
            {
                this._InventoryNameIsFullName = tag.BoolValue != 0;
                return true;
            }
            else if (tag.Name == "InventoryName")
            {
                serializer.Serialize(ref this._InventoryName);
                return true;
            }
            else if (tag.Name == "InventoryActorClass")
            {
                serializer.Serialize(ref this._InventoryActorClass);
                return true;
            }
            else if (tag.Name == "AssetGuid")
            {
                serializer.Serialize(ref this._AssetGuid);
                return true;
            }

            return base.SerializeProperty(serializer, ref tag);
        }
    }
}
