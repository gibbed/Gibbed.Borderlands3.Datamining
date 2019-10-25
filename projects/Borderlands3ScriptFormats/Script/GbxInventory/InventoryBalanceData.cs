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
    public class InventoryBalanceData : GbxGameSystemCore.ActorPartSelectionData
    {
        #region Fields
        private ObjectReference<CoreUObject.Class> _InventoryBalanceStateClass;
        private ObjectReference<InventoryBalanceData> _BaseBalanceData;
        private ObjectReference<InventoryData> _InventoryData;
        private ObjectReference<InventoryRarityData> _RarityData;
        private TaggedArray<InventoryManufacturerBalanceData> _Manufacturers;
        private RuntimeGenericPartListData _RuntimeGenericPartList;
        private bool _IsGearBuildable = true;
        private ObjectReference<GearBuilderCategoryData> _GearBuilderCategory;
        private int _MaxNumPrefixes = 2;
        private ObjectReference<DownloadableInventorySetData> _DlcInventorySetData;
        private bool _MigratedToActorPartSelectionData;
        private Guid _AssetGuid;
        private bool _DisableVisibilityAndCollision = true;
        #endregion

        #region Properties
        public ObjectReference<CoreUObject.Class> InventoryBalanceStateClass
        {
            get => this._InventoryBalanceStateClass;
            set => this._InventoryBalanceStateClass = value;
        }

        public ObjectReference<InventoryBalanceData> BaseBalanceData
        {
            get => this._BaseBalanceData;
            set => this._BaseBalanceData = value;
        }

        public ObjectReference<InventoryData> InventoryData
        {
            get => this._InventoryData;
            set => this._InventoryData = value;
        }

        public ObjectReference<InventoryRarityData> RarityData
        {
            get => this._RarityData;
            set => this._RarityData = value;
        }

        public TaggedArray<InventoryManufacturerBalanceData> Manufacturers
        {
            get => this._Manufacturers;
            set => this._Manufacturers = value;
        }

        public RuntimeGenericPartListData RuntimeGenericPartList
        {
            get => this._RuntimeGenericPartList;
            set => this._RuntimeGenericPartList = value;
        }

        public bool IsGearBuildable
        {
            get => this._IsGearBuildable;
            set => this._IsGearBuildable = value;
        }

        public ObjectReference<GearBuilderCategoryData> GearBuilderCategory
        {
            get => this._GearBuilderCategory;
            set => this._GearBuilderCategory = value;
        }

        public int MaxNumPrefixes
        {
            get => this._MaxNumPrefixes;
            set => this._MaxNumPrefixes = value;
        }

        public ObjectReference<DownloadableInventorySetData> DlcInventorySetData
        {
            get => this._DlcInventorySetData;
            set => this._DlcInventorySetData = value;
        }

        public bool MigratedToActorPartSelectionData
        {
            get => this._MigratedToActorPartSelectionData;
            set => this._MigratedToActorPartSelectionData = value;
        }

        public Guid AssetGuid
        {
            get => this._AssetGuid;
            set => this._AssetGuid = value;
        }

        public bool DisableVisibilityAndCollision
        {
            get => this._DisableVisibilityAndCollision;
            set => this._DisableVisibilityAndCollision = value;
        }
        #endregion

        protected override bool SerializeProperty(IUnrealSerializer serializer, ref PropertyTag tag)
        {
            if (tag.Name == "InventoryBalanceStateClass")
            {
                serializer.Serialize(ref this._InventoryBalanceStateClass);
                return true;
            }
            else if (tag.Name == "BaseBalanceData")
            {
                serializer.Serialize(ref this._BaseBalanceData);
                return true;
            }
            else if (tag.Name == "InventoryData")
            {
                serializer.Serialize(ref this._InventoryData);
                return true;
            }
            else if (tag.Name == "RarityData")
            {
                serializer.Serialize(ref this._RarityData);
                return true;
            }
            else if (tag.Name == "Manufacturers")
            {
                serializer.Serialize(ref this._Manufacturers);
                return true;
            }
            else if (tag.Name == "RuntimeGenericPartList")
            {
                serializer.Serialize(ref this._RuntimeGenericPartList);
                return true;
            }
            else if (tag.Name == "bIsGearBuildable")
            {
                serializer.Serialize(ref tag, ref this._IsGearBuildable);
                return true;
            }
            else if (tag.Name == "GearBuilderCategory")
            {
                serializer.Serialize(ref this._GearBuilderCategory);
                return true;
            }
            else if (tag.Name == "MaxNumPrefixes")
            {
                serializer.Serialize(ref this._MaxNumPrefixes);
                return true;
            }
            else if (tag.Name == "DlcInventorySetData")
            {
                serializer.Serialize(ref this._DlcInventorySetData);
                return true;
            }
            else if (tag.Name == "bMigratedToActorPartSelectionData")
            {
                serializer.Serialize(ref tag, ref this._MigratedToActorPartSelectionData);
                return true;
            }
            else if (tag.Name == "AssetGuid")
            {
                serializer.Serialize(ref this._AssetGuid);
                return true;
            }
            else if (tag.Name == "bDisableVisibilityAndCollision")
            {
                serializer.Serialize(ref tag, ref this._DisableVisibilityAndCollision);
                return true;
            }

            return base.SerializeProperty(serializer, ref tag);
        }
    }
}
