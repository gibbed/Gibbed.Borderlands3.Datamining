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

namespace Script.GbxGameSystemCore
{
    public class ActorPartSelectionData : GbxRuntime.GbxDataAsset
    {
        #region Fields
        private ObjectReference<ActorPartSelectionData> _BaseSelectionData;
        private ObjectReference<ActorPartSetData> _PartSetData;
        private Guid _PartSetDataGuid;
        private RuntimeActorPartListData _RuntimePartList;
        private Guid _RuntimePartListGuid;
        private Guid _InheritedRuntimePartListGuid;
        #endregion

        #region Properties
        public ObjectReference<ActorPartSelectionData> BaseSelectionData
        {
            get => this._BaseSelectionData;
            set => this._BaseSelectionData = value;
        }

        public ObjectReference<ActorPartSetData> PartSetData
        {
            get => this._PartSetData;
            set => this._PartSetData = value;
        }

        public Guid PartSetDataGuid
        {
            get => this._PartSetDataGuid;
            set => this._PartSetDataGuid = value;
        }

        public RuntimeActorPartListData RuntimePartList
        {
            get => this._RuntimePartList;
            set => this._RuntimePartList = value;
        }

        public Guid RuntimePartListGuid
        {
            get => this._RuntimePartListGuid;
            set => this._RuntimePartListGuid = value;
        }

        public Guid InheritedRuntimePartListGuid
        {
            get => this._InheritedRuntimePartListGuid;
            set => this._InheritedRuntimePartListGuid = value;
        }
        #endregion

        protected override bool SerializeProperty(IUnrealSerializer serializer, ref PropertyTag tag)
        {
            if (tag.Name == "BaseSelectionData")
            {
                serializer.Serialize(ref this._BaseSelectionData);
                return true;
            }
            else if (tag.Name == "PartSetData")
            {
                serializer.Serialize(ref this._PartSetData);
                return true;
            }
            else if (tag.Name == "PartSetDataGuid")
            {
                serializer.Serialize(ref this._PartSetDataGuid);
                return true;
            }
            else if (tag.Name == "RuntimePartList")
            {
                serializer.Serialize(ref this._RuntimePartList);
                return true;
            }
            else if (tag.Name == "RuntimePartListGuid")
            {
                serializer.Serialize(ref this._RuntimePartListGuid);
                return true;
            }
            else if (tag.Name == "InheritedRuntimePartListGuid")
            {
                serializer.Serialize(ref this._InheritedRuntimePartListGuid);
                return true;
            }

            return base.SerializeProperty(serializer, ref tag);
        }
    }
}
